from tkinter import *

class PassResetStartFrame:
    def __init__(self, root):
        self.root = root
        self._initVars()
        self.pass_reset_Frame = Frame(self.root, bg='grey', bd=5)
        self.lblpass = Label(self.pass_reset_Frame, text='Password reset', bg='gray')
        self.lblpassEmail = Label(self.pass_reset_Frame, text='Type your email', bg='gray')
        self.entrypassEmail = Entry(self.pass_reset_Frame,textvariable=self.emailText,width=25)
        self.buttonpass = Button(self.pass_reset_Frame, text='Create', width=25)
#-----------------------------------------------------------------------------------------------------------------------
    def _initVars(self):
        self.emailText = StringVar()
        self.emailText.set('email')
        self.hidden = False
# -----------------------------------------------------------------------------------------------------------------------
    def pack(self):
        self.pass_reset_Frame.pack(side=LEFT)
        self.lblpass.pack()
        self.lblpassEmail.pack()
        self.entrypassEmail.pack()
        self.buttonpass.pack()
# -----------------------------------------------------------------------------------------------------------------------
    def show(self):
        print(self.hidden)
        if(self.hidden):
            self.pass_reset_Frame.pack(side=LEFT)
            self.hidden = False
# -----------------------------------------------------------------------------------------------------------------------
    def unshow(self):
        print(self.hidden)
        if(not(self.hidden)):
            self.pass_reset_Frame.pack_forget()
            self.hidden = True
