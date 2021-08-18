import requests

def login(type:int,email:str,password:str):
  url = 'https://localhost:44388/api/login/login'
  myobj = {
         "type":type,
         "email":email,
         "pass":password
          }
  requests.packages.urllib3.disable_warnings(requests.packages.urllib3.exceptions.InsecureRequestWarning)
  resp = requests.post(url, json = myobj,verify=False)

  return resp.json()

def register(type:int,email:str,password:str,nickname:str):
  url = 'https://localhost:44388/api/register/register-start'
  myobj = {
         "type":type,
         "email":email,
         "pass":password,
         "nick":nickname
          }
  requests.packages.urllib3.disable_warnings(requests.packages.urllib3.exceptions.InsecureRequestWarning)
  resp = requests.post(url, json = myobj,verify=False)

  return resp.json()

def register_Fin(type:int,code:str):
  url = 'https://localhost:44388/api/register/register-finish'
  myobj = {
         "type":type,
         "code":code
          }
  requests.packages.urllib3.disable_warnings(requests.packages.urllib3.exceptions.InsecureRequestWarning)
  resp = requests.post(url, json = myobj,verify=False)

  return resp.json()

def card_update(type:int,email:str,paycard:str):
  url = 'https://localhost:44388/api/paycard/update-start'
  myobj = {
            "type":type,
            "email":email,
            "paycard":paycard
            }
  requests.packages.urllib3.disable_warnings(requests.packages.urllib3.exceptions.InsecureRequestWarning)
  resp = requests.post(url, json = myobj,verify=False)

  return resp.json()

def pass_reset(type:int,email:str):
  url = 'https://localhost:44388/api/password/reset-start'
  myobj = {
            "type":type,
            "email":email
            }
  requests.packages.urllib3.disable_warnings(requests.packages.urllib3.exceptions.InsecureRequestWarning)
  resp = requests.post(url, json = myobj,verify=False)

  return resp.json()
"""
while True:
  a = input()  
  r = register(1,"karl.evgrafovich@gmail.com","1488","IDDQD")
  print('register', r)  
  l = login(1,"brabudasious@gmail.com","Do_you_believe_in_devil")
  print('login', l)  
  c = card_update(1,"brabudasious@gmail.com","1111111111111111111")
  print('card update', c)
  p = pass_reset(1,"brabudasious@gmail.com")
  print('pass reset', p)
"""