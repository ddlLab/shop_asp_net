from tkinter import *

class PassResetFinishFrame:
    def __init__(self, root):
        self.root = root
        self._initVars()
        self.pass_reset_Frame = Frame(self.root, bg='grey', bd=5)
        self.lblpass = Label(self.pass_reset_Frame, text='Password reset', bg='gray')
        self.lblpassCode = Label(self.pass_reset_Frame, text='Type your code', bg='gray')
        self.entrypassCode = Entry(self.pass_reset_Frame,textvariable=self.CodeText,width=25)
        self.lblnewpass = Label(self.pass_reset_Frame, text='Type your new password', bg='gray')
        self.entrynewpass = Entry(self.pass_reset_Frame,textvariable=self.New_PassText,width=25)
        self.buttonpass = Button(self.pass_reset_Frame, text='Create', width=25)
#-----------------------------------------------------------------------------------------------------------------------
    def _initVars(self):
        self.CodeText = StringVar()
        self.CodeText.set('code')
        self.New_PassText = StringVar()
        self.New_PassText.set('code')
        self.hidden = False
# -----------------------------------------------------------------------------------------------------------------------
    def pack(self):
        self.pass_reset_Frame.pack(side=LEFT)
        self.lblpass.pack()
        self.lblpassCode.pack()
        self.entrypassCode.pack()
        self.lblnewpass.pack()
        self.entrynewpass.pack()
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

