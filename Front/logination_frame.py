from tkinter import *

class LoginationFrame:
    def __init__(self, root):
        self.root = root
        self._initVars()
        self.loginFrame = Frame(self.root, bg='grey', bd=5)
        self.lblLog     = Label(self.loginFrame, text='Logination', bg='gray')
        self.lblLogEmail = Label(self.loginFrame, text='Enter email', bg='gray')
        self.lblLogPass  = Label(self.loginFrame, text='Enter password', bg='gray')
        self.entryLogEmail = Entry(self.loginFrame,textvariable=self.emailText,width=25)
        self.entryLogPass = Entry(self.loginFrame, textvariable=self.passText, width=25)
        self.buttonLog  = Button(self.loginFrame, text='Отправить', width=25)
#-----------------------------------------------------------------------------------------------------------------------
    def _initVars(self):
        self.emailText = StringVar()
        self.emailText.set('email')
        self.passText = StringVar()
        self.passText.set('password')
        self.hidden = False
# -----------------------------------------------------------------------------------------------------------------------
    def pack(self):
        self.loginFrame.pack(side=LEFT)
        self.lblLog.pack()
        self.lblLogEmail.pack()
        self.entryLogEmail.pack()
        self.lblLogPass.pack()
        self.entryLogPass.pack()
        self.buttonLog.pack()
# -----------------------------------------------------------------------------------------------------------------------
    def show(self):
        print(self.hidden)
        if(self.hidden):
            self.loginFrame.pack(side=LEFT)
            self.hidden = False
# -----------------------------------------------------------------------------------------------------------------------
    def unshow(self):
        print(self.hidden)
        if(not(self.hidden)):
            self.loginFrame.pack_forget()
            self.hidden = True