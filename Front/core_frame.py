from tkinter import *

from registration_frame import RegistrationFrame
from pass_reset_finish_frame import PassResetFinishFrame
from pass_reset_start_frame import PassResetStartFrame
from logination_frame import LoginationFrame
from registration_frame import RegistrationFrame
from register_end_frame import RegistrationFinishFrame
from updatePaycardStart_frame import StartUptCardFrame
from updatePaycardFinish_frame import FinishUptCardFrame

class CoreFrame:
    def __init__(self,root):
       self.root = root
       self._initVars()
       self.initMainComponents()
#-----------------------------------------------------------------------------------------------------------------------
    def registerMethod(self):
        self.unpackMainComponents()

        self.regFrame = RegistrationFrame(self.root, self)
        self.regFrame.show()
        self.btnBack=Button(self.root,text='Back',width=25, command =self.initMainComponents )
        self.btnBack.pack()
#-----------------------------------------------------------------------------------------------------------------------
    def loginationMethod(self):
        self.unpackMainComponents()
        self.logFrame = LoginationFrame(self.root, self)
        self.logFrame.show()
        self.btnBack=Button(self.root,text='Back',width=25, command =self.initMainComponents )
        self.btnBack.pack()
#-----------------------------------------------------------------------------------------------------------------------
    def _initVars(self):
        self.logFrame = None
        self.regFrame = None
        self.btnBack  = None
        self.roleVarClient=IntVar()
        self.hidden = True
        self.lblIdText = StringVar()
        self.lblIdText.set('Id:unknown')
#-----------------------------------------------------------------------------------------------------------------------
    def initMainComponents(self):
       if self.regFrame!=None:
           self.regFrame.unshow()
       if self.logFrame!=None:
           self.logFrame.unshow()
       if self.btnBack!=None:
           self.btnBack.pack_forget()
       self.coreFrame = Frame(self.root, bg='grey', bd=5)
       self.lblID = Label(self.coreFrame, width = 25,textvariable = self.lblIdText)
       self.checkRoleBox=Checkbutton(self.coreFrame,text='Saler',variable=self.roleVarClient)
       self.registrationButton=Button(self.coreFrame,text='Register',width=25, command =self.registerMethod)
       self.loginationButton=Button(self.coreFrame,text='Login',width=25, command =self.loginationMethod)
       self._initVars()
       self.pack()
#-----------------------------------------------------------------------------------------------------------------------
    def unpackMainComponents(self):
        self.coreFrame.pack_forget()
        self.checkRoleBox.pack_forget()
        self.registrationButton.pack_forget()
        self.loginationButton.pack_forget()
        self.lblID.pack_forget()
#-----------------------------------------------------------------------------------------------------------------------
    def onRegisterStarted(self):
       self.regFrame.unshow()
       self.regFrame = RegistrationFinishFrame(self.root, self)
       self.regFrame.show()
       #todo : after registerFinish response setup to coreFrame.lblIdText user id 
       #p.s. do it on registerFinish Frame layer
#-----------------------------------------------------------------------------------------------------------------------
    def pack(self):
        self.coreFrame.pack()
        self.lblID.pack()
        self.checkRoleBox.pack()
        self.registrationButton.pack()
        self.loginationButton.pack()
#-----------------------------------------------------------------------------------------------------------------------
    def show(self):
        print(self.hidden)
        if(self.hidden):
            self.coreFrame.pack(side=LEFT)
            self.hidden = False
# -----------------------------------------------------------------------------------------------------------------------
    def unshow(self):
        print(self.hidden)
        if(not(self.hidden)):
            self.coreFrame.pack_forget()
            self.hidden = True


