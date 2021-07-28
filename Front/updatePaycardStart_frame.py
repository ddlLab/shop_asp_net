from tkinter import *

class StartUptCardFrame:
    def __init__(self,root):
        self.root = root
        self._initVars()
        self.startCardFrame = Frame(self.root, bg='grey', bd=5)
        self.lblStCard = Label(self.startCardFrame, text='Start Updating Card', bg='gray')
        self.lblStCardEmail = Label(self.startCardFrame, text='Type your email', bg='gray')
        self.entryStCardEmail = Entry(self.startCardFrame, textvariable=self.emailText, width=25)
        self.checkRoleBoxStCard = Checkbutton(self.startCardFrame, text='saler', variable=self.roleVarSaler)
        self.buttonStCard = Button(self.startCardFrame, text='Change', width=25)
#-----------------------------------------------------------------------------------------------------------------------
    def _initVars(self):
        self.emailText = StringVar()
        self.emailText.set('email')
        self.roleVarSaler = IntVar()
        self.roleVarSaler.set('saler')
        self.hidden = False
#-----------------------------------------------------------------------------------------------------------------------
    def pack(self):
        self.startCardFrame.pack(side=LEFT)
        self.lblStCard.pack()
        self.lblStCardEmail.pack()
        self.entryStCardEmail.pack()
        self.checkRoleBoxStCard.pack()
        self.buttonStCard.pack()
#-----------------------------------------------------------------------------------------------------------------------
    def show(self):
        print(self.hidden)
        if(self.hidden):
            self.startCardFrame.pack(side=LEFT)
            self.hidden = False
# -----------------------------------------------------------------------------------------------------------------------
    def unshow(self):
        print(self.hidden)
        if(not(self.hidden)):
            self.startCardFrame.pack_forget()
            self.hidden = True