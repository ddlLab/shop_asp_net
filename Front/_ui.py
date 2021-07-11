from tkinter import *

from registration_frame import RegistrationFrame

root = Tk()
root.title("Main title")

roleVarClient=IntVar()

checkRoleBox=Checkbutton(root,text='client',variable=roleVarClient)
checkRoleBox.pack()
'''
#checkRoleBox=Checkbutton(root,text='saler',variable=roleVarSaler)

registerFrame=Frame(root,bg='grey', bd=5)
registerFrame.pack(side=LEFT)

emailText=StringVar()
emailText.set('email')

nickText=StringVar()
nickText.set('nickname')

passText=StringVar()
passText.set('password')

lblReg=Label(registerFrame,text='Registration',bg='gray')
lblReg.pack()

lblRegEmail=Label(registerFrame,text='Type your email',bg='gray')
lblRegEmail.pack()

entryRegEmail=Entry(registerFrame,textvariable=emailText,width=25)
entryRegEmail.pack()

lblRegNick=Label(registerFrame,text='Type your nickname',bg='gray')
lblRegNick.pack()

entryRegNick=Entry(registerFrame,textvariable=nickText,width=25)
entryRegNick.pack()

lblRegPass=Label(registerFrame,text='Type your password',bg='gray')
lblRegPass.pack()

entryRegPass=Entry(registerFrame,textvariable=passText,width=25)
entryRegPass.pack()

buttonReg=Button(registerFrame,text='Create',width=25) 
buttonReg.pack()'''

regFrame = RegistrationFrame(root)
regFrame.pack()
buttonReg=Button(root,text='Hide',width=25, command =regFrame.unshow )
buttonReg.pack()
buttonReg1=Button(root,text='Show',width=25, command =regFrame.show )
buttonReg1.pack()

root.mainloop()