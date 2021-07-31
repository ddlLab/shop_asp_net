from tkinter import *

from registration_frame import RegistrationFrame
from pass_reset_finish_frame import PassResetFinishFrame
from pass_reset_start_frame import PassResetStartFrame
from logination_frame import LoginationFrame
from registration_frame import RegistrationFrame
from updatePaycardStart_frame import StartUptCardFrame
from updatePaycardFinish_frame import FinishUptCardFrame

from front_http_requests import *
import requests

class CoreFrame:
    def __init__(self,root):
       self.root = root
       self._initVars()
       self.registerMethod()
       self.loginationMethod()
       
       self.coreFrame = Frame(self.root, bg='grey', bd=5)
       
       checkRoleBox=Checkbutton(root,text='client',variable=roleVarClient)

       registrationButton=Button(root,text='Register',width=25, command =registerMethod)
       loginationButton=Button(root,text='Login',width=25, command =loginationMethod)
#-----------------------------------------------------------------------------------------------------------------------
    def registerMethod(self):
        self.loginationButton.pack_forget()

        regFrame = RegistrationFrame(root)
        buttonReg=Button(root,text='Hide registration',width=25, command =regFrame.unshow )
        buttonReg1=Button(root,text='Show registration',width=25, command =regFrame.show )
#-----------------------------------------------------------------------------------------------------------------------
    def loginationMethod(self):
        self.registrationButton.pack_forget()

        logFrame = LoginationFrame(root)
        buttonLog=Button(root,text='Hide login',width=25, command =logFrame.unshow )
        buttonLog1=Button(root,text='Show login',width=25, command =logFrame.show )
#-----------------------------------------------------------------------------------------------------------------------
    def _initVars(self):
        roleVarClient=IntVar()
        self.hidden = False
#-----------------------------------------------------------------------------------------------------------------------
    def pack(self):
        checkRoleBox.pack()

        registrationButton.pack()
        loginationButton.pack()
        
        regFrame.pack()
        buttonReg.pack()
        buttonReg1.pack()

        logFrame.pack()
        buttonLog.pack()
        buttonLog1.pack()
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


