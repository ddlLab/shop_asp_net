from tkinter import *

class FinishUptCardFrame:
    def __init__(self,root):
        self.root = root
        self._initVars()
        self.finishCardFrame = Frame(self.root, bg='grey', bd=5)
        self.lblFinCard = Label(self.finishCardFrame, text='Finish Updating Card', bg='gray')
        self.lblFinCardCode = Label(self.finishCardFrame, text='Type your code', bg='gray')
        self.entryFinCardCode= Entry(self.finishCardFrame, textvariable=self.codeText, width=25)
        self.lblFinNewCard = Label(self.finishCardFrame, text='Type your new paycard', bg='gray')
        self.entryFinNewCard= Entry(self.finishCardFrame, textvariable=self.newCardText, width=25)
        self.checkRoleBoxFinCard = Checkbutton(self.finishCardFrame, text='saler', variable=self.roleVarSaler)
        self.buttonFinCard = Button(self.finishCardFrame, text='Change', width=25)
#-----------------------------------------------------------------------------------------------------------------------
    def _initVars(self):
        self.codeText = StringVar()
        self.codeText.set('code')
        self.newCardText = StringVar()
        self.newCardText.set('new_card')
        self.roleVarSaler = IntVar()
        self.roleVarSaler.set('saler')
        self.hidden = False
#-----------------------------------------------------------------------------------------------------------------------
    def pack(self):
        self.finishCardFrame.pack(side=LEFT)
        self.lblFinCard.pack()
        self.lblFinCardCode.pack()
        self.entryFinCardCode.pack()
        self.lblFinNewCard.pack()
        self.entryFinNewCard.pack()
        self.checkRoleBoxFinCard.pack()
        self.buttonFinCard.pack()
#-----------------------------------------------------------------------------------------------------------------------
    def show(self):
        print(self.hidden)
        if(self.hidden):
            self.finishCardFrame.pack(side=LEFT)
            self.hidden = False
# -----------------------------------------------------------------------------------------------------------------------
    def unshow(self):
        print(self.hidden)
        if(not(self.hidden)):
            self.finishCardFrame.pack_forget()
            self.hidden = True