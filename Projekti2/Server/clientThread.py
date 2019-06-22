from metodat import * 
import socket 
import sys
import base64
from CyberRSA import Cipher


def clientthread(conn, addr, s):

    Cipher.generate_keys()
    try:
        
        f = open("rsapub.pem",'r')
        l = base64.b64encode(bytes(f.read(1024), "utf-8"))
        conn.send(l)
        l = f.read(1024)
        f.close()

        welcome = b"""Zgjedhni njerin nga Operacionet 
                    (Login ose register)? """ 
        
        conn.send(base64.b64encode(welcome))
        while True:
            req = GetMessageAndKey(conn)
            desKey = req['key']
            decMessage = req['message']

            print("Klienti %s:%s kerkoi: %s" %(addr[0], addr[1], decMessage))
            method = decMessage.upper().strip()
            
            if method == "LOGIN":
                MESSAGE = login(conn, desKey)
            elif method == "REGISTER":
                MESSAGE =  register(conn, desKey)
            else:
                print("Bravo ne kurgjo")

        MESSAGE += "Lidhja me " + str(addr[0]) + ":" + str(addr[1]) + " u nderpre"
        print(MESSAGE) 
        conn.close()        
    except Exception:
        print(sys.exc_info())
        conn.close()    


