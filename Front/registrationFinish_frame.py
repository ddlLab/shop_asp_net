from tkinter import *
import front_http_requests

class RegistrationFinishFrame:
    def __init__(self, root, coreFrame):
        self.root = root
        self.mainFrame = coreFrame
        self._initVars()
        self.registerFinishFrame = Frame(self.root, bg='grey', bd=5)
        self.lblRegFin = Label(self.registerFinishFrame, text='Registration', bg='gray')
        self.lblRegFinCodeFirst = Label(self.registerFinishFrame, text='Code was sent on your email', bg='gray')
        self.lblRegFinCodeSecond = Label(self.registerFinishFrame, text='Type your code', bg='gray')
        self.entryRegFinCode = Entry(self.registerFinishFrame,textvariable=self.codeText,width=25)
        self.buttonRegFin = Button(self.registerFinishFrame, text='Finish', width=25,command=self.finish)
        self.pack()
#-----------------------------------------------------------------------------------------------------------------------
    def _initVars(self):
        self.codeText = StringVar()
        self.codeText.set('')
        self.hidden = True
# -----------------------------------------------------------------------------------------------------------------------
    def pack(self):
        self.registerFinishFrame.pack()
        self.lblRegFin.pack()
        self.lblRegFinCodeFirst.pack()
        self.lblRegFinCodeSecond.pack()
        self.entryRegFinCode.pack()
        self.buttonRegFin.pack()
# -----------------------------------------------------------------------------------------------------------------------
    def show(self):
        print(self.hidden)
        if(self.hidden):
            self.registerFinishFrame.pack()
            self.hidden = False
# -----------------------------------------------------------------------------------------------------------------------
    def unshow(self):
        print(self.hidden)
        if(not(self.hidden)):
            self.registerFinishFrame.pack_forget()
            self.hidden = True
# -----------------------------------------------------------------------------------------------------------------------
    def finish(self):
        end=front_http_requests.register_Fin(self.mainFrame.roleVarClient.get(),self.codeText.get())
        print(end)
        if int(end['result'])==0:
            self.mainFrame.onRegisterStarted()