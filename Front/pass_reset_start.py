from tkinter import *

from pass_reset_start_frame import PassResetStartFrame

root = Tk()
root.title("Охаё")

roleVarClient=IntVar()

checkRoleBox=Checkbutton(root,text='client',variable=roleVarClient)
checkRoleBox.pack()

passFrame = PassResetStartFrame(root)
passFrame.pack()
buttonPass =Button(root,text='Hide',width=25, command = passFrame.unshow )
buttonPass.pack()
buttonPass1=Button(root,text='Show',width=25, command =passFrame.show )
buttonPass1.pack()

root.mainloop()