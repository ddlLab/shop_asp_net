from tkinter import *
import front_http_requests

class LoginationFrame:
    def __init__(self,root, coreFrame):
        self.root = root
        self.mainFrame = coreFrame
        print('roleVarClient:',self.mainFrame.roleVarClient.get())
        self._initVars()
        self.loginationFrame = Frame(self.root, bg='grey', bd=5)
        self.lblLog = Label(self.loginationFrame , text='Logination', bg='gray')
        self.lblLogEmail = Label(self.loginationFrame, text='Type your email', bg='gray')
        self.lblLogPass = Label(self.loginationFrame, text='Type your password',bg='gray')
        self.entryLogEmail = Entry(self.loginationFrame, width = 25,textvariable = self.emailText)
        self.entryLogPass = Entry(self.loginationFrame, width = 25,textvariable = self.passText)
        self.buttonLog = Button(self.loginationFrame, text='Login', width = 25,command=self.login)
        self.pack()
#-----------------------------------------------------------------------------------------------------------------------
    def _initVars(self):
        self.emailText = StringVar()
        self.emailText.set('dima280803@gmail.com')
        self.passText = StringVar()
        self.passText.set('11qqAAzz')
        self.hidden = True
#-----------------------------------------------------------------------------------------------------------------------
    def pack(self):
        self.loginationFrame.pack()
        self.lblLog.pack()
        self.lblLogEmail.pack()
        self.entryLogEmail.pack()
        self.lblLogPass.pack()
        self.entryLogPass.pack()
        self.buttonLog.pack()
#-----------------------------------------------------------------------------------------------------------------------
    def show(self):
        print(self.hidden)
        if(self.hidden):
            self.loginationFrame.pack()
            self.hidden = False
# -----------------------------------------------------------------------------------------------------------------------
    def unshow(self):
        print(self.hidden)
        if(not(self.hidden)):
            self.loginationFrame.pack_forget()
            self.hidden = True
# -----------------------------------------------------------------------------------------------------------------------
    def login(self):
        res=front_http_requests.login(self.mainFrame.roleVarClient.get(),self.emailText.get(),self.passText.get())
        print(res)
        if res != None and res["result"] == 0:
            self.mainFrame.loginationMethodFinished(res["user_id"])
