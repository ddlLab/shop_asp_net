from tkinter import *
import front_http_requests

class RegistrationFrame:
    def __init__(self, root, coreFrame):
        self.root = root
        self.mainFrame = coreFrame
        print('roleVarClient:',self.mainFrame.roleVarClient.get())
        self._initVars()
        self.registerFrame = Frame(self.root, bg='grey', bd=5)
        self.lblReg = Label(self.registerFrame, text='Registration', bg='gray')
        self.lblRegEmail = Label(self.registerFrame, text='Type your email', bg='gray')
        self.lblRegNick = Label(self.registerFrame, text='Type your nickname', bg='gray')
        self.lblRegPass = Label(self.registerFrame, text='Type your password', bg='gray')
        self.entryRegEmail = Entry(self.registerFrame,textvariable=self.emailText,width=25)
        self.entryRegNick = Entry(self.registerFrame, textvariable=self.nickText, width=25)
        self.entryRegPass = Entry(self.registerFrame, textvariable=self.passText, width=25)
        self.buttonReg = Button(self.registerFrame, text='Create', width=25,command=self.register)
        self.pack()
#-----------------------------------------------------------------------------------------------------------------------
    def _initVars(self):
        self.emailText = StringVar()
        self.emailText.set('karl.evgrafovich@gmail.com')
        self.nickText = StringVar()
        self.nickText.set('Jugde')
        self.passText = StringVar()
        self.passText.set('Hello_there')
        self.hidden = True
# -----------------------------------------------------------------------------------------------------------------------
    def pack(self):
        self.registerFrame.pack()
        self.lblReg.pack()
        self.lblRegEmail.pack()
        self.entryRegEmail.pack()
        self.lblRegNick.pack()
        self.entryRegNick.pack()
        self.lblRegPass.pack()
        self.entryRegPass.pack()
        self.buttonReg.pack()
# -----------------------------------------------------------------------------------------------------------------------
    def show(self):
        print(self.hidden)
        if(self.hidden):
            self.registerFrame.pack()
            self.hidden = False
# -----------------------------------------------------------------------------------------------------------------------
    def unshow(self):
        print(self.hidden)
        if(not(self.hidden)):
            self.registerFrame.pack_forget()
            self.hidden = True
# -----------------------------------------------------------------------------------------------------------------------
    def register(self):
        res=front_http_requests.register(self.mainFrame.roleVarClient.get(),self.emailText.get(),self.passText.get(),self.nickText.get())
        print(res)
        if int(res['result'])==0:
            self.mainFrame.onRegisterStarted()
            '''
            self.lblRegCode     = Label(self.registerFrame, text='Type your code', bg='gray')
            self.entryRegCode   = Entry(self.registerFrame,textvariable=self.codeText,width=25)
            self.buttonRegFin   = Button(self.registerFrame, text='Finish', width=25,command=self.finish)
            self.codeText = StringVar()
            self.codeText.set('code')
            self.lblRegCode.pack()
            self.entryRegCode.pack()
            self.buttonRegFin.pack()'''
# -----------------------------------------------------------------------------------------------------------------------
    def finish(self):
        end=front_http_requests.register_Fin(self.mainFrame.roleVarClient.get(),self.codeText.get())
        print(end)