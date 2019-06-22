import socket
import sys 
import os
import datetime
import random
import base64
from Crypto.Cipher import DES
from Crypto import Random
from Crypto.PublicKey import RSA
import datetime
from Crypto.Hash import SHA256
from Crypto.Signature import PKCS1_v1_5
from lxml import etree, objectify
import hashlib
import binascii
import jwt

def login(conn, desKey):
    MESSAGE = "Email: "
    response = MakeMessage(desKey, MESSAGE) 
    conn.send(response)

    res = GetMessageAndKey(conn)
    email = res['message'] 
    desKey = res['key']
    MESSAGE = "Password:"
    response = MakeMessage(desKey, MESSAGE)
    conn.send(response)

    res = GetMessageAndKey(conn)
    password = res['message'] 
    desKey = res['key']
    
    rec = getTeacherFromEmail(email)

    if not rec['password'] or not rec["salt"]:
        response = MakeMessage(desKey, "No user found with this email. Please register first\nType Login or Register: ")
    else:
        if verifyPassword(rec['password'], rec['salt'], password):
            teacher = createTeacher({"id": rec['id'],
                             "title" : rec['title'],
                             "name" : rec['name'],
                             "email" : email,
                             "salary" : rec['salary']}, True)

            createXML("teacher.xml")
            CreateElement(teacher, "teacher.xml")      
            res = DisplayUser("teacher.xml", teacher)

            if res['message']:
                jwtEnc = res['message']
                response = MakeMessage(desKey, "YouDetailsAreComingVerified")
                conn.send(response)
                conn.send(jwtEnc)    
        else:
            response = MakeMessage(desKey, "Incorrect password\nType Login or Register to try again: ")
    conn.send(response)


def register(conn, desKey):

    MESSAGE = "Title: "
    response = MakeMessage(desKey, MESSAGE) 
    conn.send(response)
    
    res = GetMessageAndKey(conn)
    Title = res['message'] 
    desKey = res['key']


    MESSAGE = "Name: "
    response = MakeMessage(desKey, MESSAGE) 
    conn.send(response)
    
    res = GetMessageAndKey(conn)
    Name = res['message'] 
    desKey = res['key']

    MESSAGE = "Email: "
    response = MakeMessage(desKey, MESSAGE) 
    conn.send(response)
    
    res = GetMessageAndKey(conn)
    Email = res['message'].strip().lower() 
    desKey = res['key']


    MESSAGE = "Password: "
    response = MakeMessage(desKey, MESSAGE) 
    conn.send(response)
    
    res = GetMessageAndKey(conn)
    Password = res['message'] 
    desKey = res['key']


    hashdValues = hashPassword(Password)
    Password = hashdValues['password']
    Salt = hashdValues['salt']


    MESSAGE = "Salary: "
    response = MakeMessage(desKey, MESSAGE) 
    conn.send(response)
    
    res = GetMessageAndKey(conn)
    Salary = res['message'] 
    desKey = res['key']

    dbFile = os.path.isfile("database.xml")
    if not dbFile:
        createXML("database.xml")

    Id = getId()
    teacher = createTeacher({"id": Id,
                             "title" : Title,
                             "name" : Name,
                             "email" : Email,
                             "password" : Password,
                             "salary" : Salary,
                             "salt": Salt }, False)


    CreateElement(teacher, "database.xml")

    teacher = createTeacher({"id": Id,
                             "title" : Title,
                             "name" : Name,
                             "email" : Email,
                             "salary" : Salary}, True)

    createXML("teacher.xml")


    CreateElement(teacher, "teacher.xml")      
    res = DisplayUser("teacher.xml", teacher)

    if res['message']:
        jwtEnc = res['message']
        response = MakeMessage(desKey, "YouDetailsAreComingVerified")
        conn.send(response)
        conn.send(jwtEnc)

def EncryptWithDes(data, key, iv):
    msg = data
    cipher = DES.new(key)
    cipher.mode = DES.MODE_CBC
    cipher.IV = iv
    if isinstance(data, str):
        msg = base64.b64encode(bytes(data, "utf-8"))
    return cipher.encrypt(msg)

def DecryptWithDes(data, key, iv):
    cipher = DES.new(key)
    cipher.mode = DES.MODE_CBC
    cipher.IV = iv    
    return base64.b64decode(cipher.decrypt(data)).decode()

def GetMessageAndKey(conn):
    data = base64.b64decode(conn.recv(1024))
    desIv = data[:8]
    desKey = data[8:136]
    encMessage = data[136:]
    f = open('rsakey.pem', 'r')
    privateKey = RSA.importKey(f.read())
    desKey = privateKey.decrypt(desKey)
    decMessage = DecryptWithDes(encMessage, desKey, desIv)
    ret = dict()
    ret['key'] = desKey
    ret['message'] = decMessage.strip()
    return ret

def MakeMessage(desKey, MESSAGE):
    desIv = Random.get_random_bytes(8)
    if isinstance(MESSAGE, str):
        toAdd = 6 - (len(MESSAGE) % 6) 
        if(toAdd != 0):
            while(toAdd != 0):
                MESSAGE += " "
                toAdd -= 1 
    encryptedMessage = EncryptWithDes(MESSAGE, desKey, desIv) #base64
    return base64.b64encode(desIv + encryptedMessage)      

def createXML(name):
        xml = '''<?xml version="1.0" ?>
        <Teachers>
        </Teachers>
        '''
        parser = etree.XMLParser(ns_clean=True, recover=True, encoding='utf-8')
        root = objectify.fromstring(xml, parser)        
        objectify.deannotate(root)
        etree.cleanup_namespaces(root)
        

        obj_xml = etree.tostring(root,
                             pretty_print=True,
                             xml_declaration=True).decode()
 
        try:
            with open(name, "w") as xml_writer:
                xml_writer.write(obj_xml)
        except IOError:
            pass

def createTeacher(data, forUser):
    teacher = objectify.Element("Teacher")
    teacher.id = data['id']
    teacher.title = data["title"]
    teacher.name = data["name"]
    teacher.email = data["email"]
    teacher.salary = data["salary"]
    if not forUser:
        teacher.password = data["password"]
        teacher.salt = data['salt']
    return teacher         

def hashPassword(password):
    salt = hashlib.sha256(os.urandom(60)).hexdigest().encode('ascii')
    hashedPassword = hashlib.pbkdf2_hmac('sha512', password.encode('utf-8'), 
                                salt, 100000)
    hashedPassword = binascii.hexlify(hashedPassword)
    ret = dict()
    ret['password'] = (hashedPassword).decode('ascii')
    ret['salt'] = salt.decode('ascii')
    return ret
def verifyPassword(stored_password, salt,  provided_password):
    hashedPassword = hashlib.pbkdf2_hmac('sha512', 
                                  provided_password.encode('utf-8'), 
                                  salt.encode('ascii'), 
                                  100000)
    hashedPassword = binascii.hexlify(hashedPassword).decode('ascii')
    return hashedPassword == stored_password    



def getTeacherFromEmail(email):
    id = ""
    title = ""
    name = ""
    password = ""
    salary = ""
    salt = ""
    try:
        basePath = os.path.dirname(os.path.abspath(__file__))
        email = email.strip().lower()
        parser = etree.XMLParser(remove_blank_text=True)
        tree = etree.parse(basePath + "/database.xml", parser)
        root = tree.getroot()
        for teacher in root.getchildren():
            if email == teacher.getchildren()[3].text:
                id = teacher.getchildren()[0].text
                title = teacher.getchildren()[1].text
                name = teacher.getchildren()[2].text
                salary = teacher.getchildren()[4].text
                password = teacher.getchildren()[5].text
                salt = teacher.getchildren()[6].text
                break
    except Exception:
        pass

    ret = dict()    
    ret['id'] = id
    ret['title'] = title
    ret['name'] = name
    ret['password'] = password
    ret['salary'] = salary
    ret['salt'] = salt        
    return ret

def getId():
    ID = 0
    parser = etree.XMLParser(remove_blank_text=True)
    tree = etree.parse("database.xml", parser)
    root = tree.getroot()
    try:
        for teacher in root.getchildren():
            test = int(teacher.getchildren()[0].text)
            if(test > ID):
                ID = test
        ID = ID + 1         
    except Exception:
        ID = 1       
    return ID     

def CreateElement(teacher, name):
    
    parser = etree.XMLParser(remove_blank_text=True)
    tree = etree.parse(name, parser)
    
    root = tree.getroot()                          
    root.append(teacher)                         
    objectify.deannotate(tree)
    etree.cleanup_namespaces(tree)
    obj_xml = etree.tostring(root, pretty_print=True,
                             xml_declaration=True, 
                             ).decode()
 
    try:
        with open(name, "w") as xml_writer:
            xml_writer.write(obj_xml)
    except IOError: 
        pass    


def DisplayUser(name, teacher):
    f =  open('rsakey.pem', 'r') 
    privateKey = RSA.importKey(f.read())
    f.close()
   
    parser = etree.XMLParser(remove_blank_text=True, remove_comments=True, 
        remove_pis=True, strip_cdata=True)
    tree = etree.parse("teacher.xml", parser)
    objectify.deannotate(tree)
    etree.cleanup_namespaces(tree)
    root = tree.getroot()
    message = etree.tostring(root).decode()
    
    encodedWithJwt = jwt.encode({'details': message}, 'secret', algorithm='HS256')
    os.remove('teacher.xml')
    ret = dict()
    # ret['signed'] = 
    ret['message'] = encodedWithJwt
    return ret
