import socket 
import sys
import os
import base64
import getpass
from Crypto.Cipher import DES
from Crypto import Random
from Crypto.PublicKey import RSA
from lxml import objectify, etree
import jwt

defaultHost = 'localhost'
defaultPort = 12000

### Metoda me te cilen starton Klienti
def connect(host, port):

    BUFFER_SIZE = 1024 
    MESSAGE = ''
    data = ''
    ### Krijojm socketin ne protokollin TCP
    fiekTCP = socket.socket(socket.AF_INET, socket.SOCK_STREAM) 
    try:
        ### Tetojme kyqjen ne hostin dhe portin e kerkuar. 
        fiekTCP.connect((host, port))
        print("Socket-i u krijua me sukses ne hostin " + host + " me port " + str(port))
    ### Kontrolli per gabime  
    except ConnectionRefusedError:
        print("Nuk mund te krijohet lidhja me server")
        vazhdo()
     
    
    f = open('rsapub.pem', 'w')
    data = base64.b64decode(fiekTCP.recv(1024)).decode()
    f.write(data)
    f.close()    

    f = open('rsapub.pem', 'r')
    public_key = RSA.importKey(f.read())

    data = base64.b64decode(fiekTCP.recv(BUFFER_SIZE)).decode()
    
    MESSAGE = input("Serveri: " + data + " ")
    if not MESSAGE.strip():
        MESSAGE = "register"


    while MESSAGE != 'exit' and data != 'exit':
        try:
            req = MakeMessageAndKey(public_key, MESSAGE)
            request = req['message']
            desKey = req['key']

            fiekTCP.send(request)   

            ### Presim pergjigje nga serveri
            data = base64.b64decode(fiekTCP.recv(BUFFER_SIZE))
            desIv = data[:8]
            encMessage = data[8:]
            data = DecryptWithDes(encMessage, desKey, desIv).strip()


            ### Kontrollojm pergjigjen
            if  data == 'exit':
                break
            elif data == "Password:":
                MESSAGE = getpass.getpass("Serveri: " + data + " ")
        
            elif data == "YouDetailsAreComingVerified":
                GetDetailsAndSignature(fiekTCP, public_key)
                fiekTCP.close()
            else:        
            ### Presim kerkesen nga tastiera    
                MESSAGE = input("Serveri: " + data + " ")
            if not MESSAGE:
                MESSAGE = 'null'
            ### Dergojme kerkesen ne servers     



        ### Kontrolli per gabime  
        except KeyboardInterrupt:
            MESSAGE = 'ProcessTerminatedByUser'
            fiekTCP.send(str.encode(MESSAGE))
            print('\nJu e mbyllet socketin')
            fiekTCP.close()    
            break
        except BrokenPipeError:
            print('\nServeri eshte down')
            fiekTCP.close()    
            break    
        except OSError:  
            fiekTCP.close()    
            break
        except Exception:
            print(sys.exc_info()[0])
            break


    print('Socketi u mbyll') 
    ### Mbyllim socketin me serverin
    fiekTCP.close() 
    vazhdo()

### Metode ndihmese per te vazhduar apo jo 
def vazhdo(): 
    try:
        input1 = input("A deshironi te lidheni me ndonje server tjeter(PO): ").upper()
        if not input1 or input1 == "PO":
            host = hosti()
            port = porti()    
            connect(host, port)
        else: 
            print("Scripta u ndal")    
    ### Kontrolli per gabime          
    except KeyboardInterrupt:
        print("\nScripta u ndal")
## Metoda per te zgjedhur hostin              
def hosti():
    try:
        input1 = input("Shkruani host-in me te cilin doni te lidheni.(default %s): " %defaultHost)
        if not input1:
            return defaultHost
        else: 
            isIp = validate_ip(input1)
            if not isIp:
                try:
                    host_ip = socket.gethostbyname(input1)
                    return host_ip
                except socket.gaierror:
                    print("Nuk ishte e mundur te gjindet hosti, Provoni serish")
                    hosti()
            else: 
                return input1    
    ### Kontrolli per gabime                    
    except KeyboardInterrupt:
        print("\nScripta u ndal")
### Metoda per te zgjedhur portin   
def porti():
    try:
        input2 = input("Shkruani portin me te cilin doni te lidheni.(default %s): " %defaultPort)        
        if not input2 :
            return defaultPort
        else:
            try:
                val = int(input2)
                return val
            except:
                print("Porti duhet te jete nje numer.") 
                porti()   
    except KeyboardInterrupt:
        print("\nScripta u ndal")    
### Metoda e cila teston ip se a jan ne formartin IPv4        
def validate_ip(s):
    a = s.split('.')
    if len(a) != 4:
        return False
    for x in a:
        if not x.isdigit():
            return False
        i = int(x)
        if i < 0 or i > 255:
            return False        
    return True

def EncryptWithDes(data, key, iv):
    cipher = DES.new(key)
    cipher.mode = DES.MODE_CBC
    cipher.IV = iv
    return cipher.encrypt(base64.b64encode(bytes(data, "utf-8")))
    

def DecryptWithDes(data, key, iv):
    cipher = DES.new(key)
    cipher.mode = DES.MODE_CBC
    cipher.IV = iv    
    return base64.b64decode(cipher.decrypt(data)).decode()

def MakeMessageAndKey(public_key, MESSAGE):
    toAdd = 6 - (len(MESSAGE) % 6) 
    if(toAdd != 0):
        while(toAdd != 0):
            MESSAGE += " "
            toAdd -= 1 
    desKey = Random.get_random_bytes(8)
    desIv = Random.get_random_bytes(8)
    encryptedMessage = EncryptWithDes(MESSAGE, desKey, desIv) #base64
    desKeyEnc = public_key.encrypt(desKey, Random.get_random_bytes(8))
    request = base64.b64encode(desIv +  desKeyEnc[0] + encryptedMessage)
    ret = dict()
    ret['message'] = request
    ret['key'] = desKey
    return ret 

def GetDetailsAndSignature(conn, public_key):
 
    message = conn.recv(1024)
 
    decodedFromJWT = jwt.decode(message, "secret", algorithms='HS256')
    createXML(decodedFromJWT['details'])
    details = GetDetails()
    os.remove('details.xml')
    for el in details:
        print(el + " : " + details[el])
    print()    
       


def createXML(details):
        xml = "<?xml version='1.0' ?>" + details
        parser = etree.XMLParser(ns_clean=True, recover=True, encoding='utf-8')
        root = objectify.fromstring(xml, parser)        
        objectify.deannotate(root)
        etree.cleanup_namespaces(root)
        

        obj_xml = etree.tostring(root,
                             pretty_print=True,
                             xml_declaration=True).decode()
 
        try:
            with open("details.xml", "w") as xml_writer:
                xml_writer.write(obj_xml)
        except IOError:
            pass    

def GetDetails():
    id = ""
    title = ""
    email = ""
    name = ""
    salary = ""
    try:
        parser = etree.XMLParser(remove_blank_text=True)
        tree = etree.parse("details.xml", parser)
        root = tree.getroot()
        for teacher in root.getchildren():
            id = teacher.getchildren()[0].text
            title = teacher.getchildren()[1].text
            name = teacher.getchildren()[2].text
            email = teacher.getchildren()[3].text
            salary = teacher.getchildren()[4].text
    except Exception:
        pass

    ret = dict()    
    ret['id'] = id
    ret['title'] = title
    ret['name'] = name
    ret['email'] = email
    ret['salary'] = salary
    return ret    
