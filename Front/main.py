from tkinter import *

from registration_frame import RegistrationFrame
from pass_reset_finish_frame import PassResetFinishFrame
from pass_reset_start_frame import PassResetStartFrame
from logination_frame import LoginationFrame

root = Tk()
root.title("Main title")

roleVarClient=IntVar()

checkRoleBox=Checkbutton(root,text='client',variable=roleVarClient)
checkRoleBox.pack()

regFrame = RegistrationFrame(root)
regFrame.pack()
buttonReg=Button(root,text='Hide registration',width=25, command =regFrame.unshow )
buttonReg.pack()
buttonReg1=Button(root,text='Show registration',width=25, command =regFrame.show )
buttonReg1.pack()

resetFinishFrame = PassResetFinishFrame(root)
resetFinishFrame.pack()
buttonRes=Button(root,text='Hide reset finish',width=25, command =resetFinishFrame.unshow )
buttonRes.pack()
buttonRes1=Button(root,text='Show reset finish',width=25, command =resetFinishFrame.show )
buttonRes1.pack()

resetStartFrame = PassResetStartFrame(root)
resetStartFrame.pack()
buttonResS=Button(root,text='Hide reset start',width=25, command =resetStartFrame.unshow )
buttonResS.pack()
buttonResS1=Button(root,text='Show reset start',width=25, command =resetStartFrame.show )
buttonResS1.pack()

logFrame = LoginationFrame(root)
logFrame.pack()
buttonLog=Button(root,text='Hide login',width=25, command =logFrame.unshow )
buttonLog.pack()
buttonLog1=Button(root,text='Show login',width=25, command =logFrame.show )
buttonLog1.pack()

root.mainloop()