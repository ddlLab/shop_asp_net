from tkinter import *

class RegistrationFrame:
    def __init__(self, root):
        self.root = root
        self._initVars()
        self.registerFrame = Frame(self.root, bg='grey', bd=5)
        self.lblReg = Label(self.registerFrame, text='Registration', bg='gray')
        self.lblRegEmail = Label(self.registerFrame, text='Type your email', bg='gray')
        self.lblRegNick = Label(self.registerFrame, text='Type your nickname', bg='gray')
        self.lblRegPass = Label(self.registerFrame, text='Type your password', bg='gray')
        self.entryRegEmail = Entry(self.registerFrame,textvariable=self.emailText,width=25)
        self.entryRegNick = Entry(self.registerFrame, textvariable=self.nickText, width=25)
        self.entryRegPass = Entry(self.registerFrame, textvariable=self.passText, width=25)
        self.buttonReg = Button(self.registerFrame, text='Create', width=25)
#-----------------------------------------------------------------------------------------------------------------------
    def _initVars(self):
        self.emailText = StringVar()
        self.emailText.set('email')
        self.nickText = StringVar()
        self.nickText.set('nickname')
        self.passText = StringVar()
        self.passText.set('password')
        self.hidden = False
# -----------------------------------------------------------------------------------------------------------------------
    def pack(self):
        self.registerFrame.pack(side=LEFT)
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
            self.registerFrame.pack(side=LEFT)
            self.hidden = False
# -----------------------------------------------------------------------------------------------------------------------
    def unshow(self):
        print(self.hidden)
        if(not(self.hidden)):
            self.registerFrame.pack_forget()
            self.hidden = True
