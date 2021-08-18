
from tkinter import *
import front_http_requests

class RegistrationFinishFrame:
    def __init__(self, root, coreFrame):
        self.root = root
        self.mainFrame = coreFrame
        self._initVars()
        self.registerFinFrame = Frame(self.root, bg='grey', bd=5)
        self.lblRegCode     = Label(self.registerFinFrame, text='Type your code', bg='gray')
        self.entryRegCode   = Entry(self.registerFinFrame,textvariable=self.codeText,width=25)
        self.buttonRegFin   = Button(self.registerFinFrame, text='Finish', width=25,command=self.finish)
# -----------------------------------------------------------------------------------------------------------------------
    def _initVars(self):
        self.codeText = StringVar()
        self.codeText.set('code')
        self.hidden = True
# -----------------------------------------------------------------------------------------------------------------------
    def pack(self):
        self.registerFinFrame.pack()
        self.lblRegCode.pack()
        self.entryRegCode.pack()
        self.buttonRegFin.pack()
# -----------------------------------------------------------------------------------------------------------------------
    def show(self):
        if(self.hidden):
            self.pack()
            self.hidden = False
# -----------------------------------------------------------------------------------------------------------------------
    def unshow(self):
        if(not(self.hidden)):
            self.registerFinFrame.pack_forget()
            self.hidden = True
# -----------------------------------------------------------------------------------------------------------------------
    def finish(self):
        end=front_http_requests.register_Fin(self.mainFrame.roleVarClient.get(),self.codeText.get())
        print(end)
