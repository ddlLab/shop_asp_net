import requests

def login(type:int, email:str, password:str):
	url = 'https://localhost:44388/api/login/login'
	myobj = {
		"type": type,
		"email" : email,
		"pass": password
	}
	requests.packages.urllib3.disable_warnings(requests.packages.urllib3.exceptions.InsecureRequestWarning)
	resp = requests.post(url, json = myobj, verify=False)
	return resp.json()

def register_start(type:int, email:str, password:str , nick:str):
	url ='https://localhost:44388/api/register/register-start'
	myobj = {
		"type": type,
		"email" : email,
		"pass": password,
		"nick": nick
	}
	requests.packages.urllib3.disable_warnings(requests.packages.urllib3.exceptions.InsecureRequestWarning)
	resp = requests.post(url, json = myobj, verify=False)
	return resp.json()

def register_finish(type:int, code:str):
	url ='https://localhost:44388/api/register/register-finish'
	myobj = {
		"type": type,
		"code" : code
	}
	requests.packages.urllib3.disable_warnings(requests.packages.urllib3.exceptions.InsecureRequestWarning)
	resp = requests.post(url, json = myobj, verify=False)
	return resp.json()

def reset_pass_start(type:int ,email:str):
	url='https://localhost:44388/api/password/register-start'
	myobj = {
		"type" : type,
		"email" : email
	}
	requests.packages.urllib3.disable_warnings(requests.packages.urllib3.exceptions.InsecureRequestWarning)
	resp = requests.post(url, json = myobj, verify=False)
	return resp.json()

def reset_pass_finish(type:int ,code:str , new_pass:str):
	url='https://localhost:44388/api/password/register-finish'
	myobj = {
		"type" : type,
		"code" : code,
		"new_pass" : new_pass
	}
	requests.packages.urllib3.disable_warnings(requests.packages.urllib3.exceptions.InsecureRequestWarning)
	resp = requests.post(url, json = myobj, verify=False)
	return resp.json()

def update_card_start(type:int ,email:str):
	url='https://localhost:44388/api/paycard/update-start'
	myobj = {
		"type" : type,
		"email" : email
	}
	requests.packages.urllib3.disable_warnings(requests.packages.urllib3.exceptions.InsecureRequestWarning)
	resp = requests.post(url, json = myobj, verify=False)
	return resp.json()

def update_card_finish(type:int ,code:str , new_pass:str):
	url='https://localhost:44388/api/paycard/update-finish'
	myobj = {
		"type" : type,
		"code" : code,
		"new_card" : new_card
	}
	requests.packages.urllib3.disable_warnings(requests.packages.urllib3.exceptions.InsecureRequestWarning)
	resp = requests.post(url, json = myobj, verify=False)
	return resp.json()

while True:
	a = input()
	r = login(1, "dima280803@gmail.com", "qqAAzz11")
	print('login', r)
	r = register_start(1, "dima280803@gmail.com", "qqAAzz11","test")
	print('register_start', r)
	r = register_finish(1,"tr063J")
	print('register_finish', r)
	r = reset_pass_start(1,"dima280803@gmail.com")
	print('reset_pass_start', r)
	r = reset_pass_finish(1,"tr063J","AAsss1f")
	print('reset_pass_finish', r)
	r = update_card_start(1,"dima280803@gmail.com")
	print('reset_card_start', r)
	r = update_card_finish(1,"tr063J","AAsss1f")
	print('reset_card_finish', r)


