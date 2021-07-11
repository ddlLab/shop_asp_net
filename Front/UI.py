from tkinter import *

from logination_frame import LoginationFrame

root=Tk()
root.title("Охаё")

client  = Checkbutton(text='Client',bg='gray')
'''
e = StringVar()
e.set("Email")
p = StringVar()
p.set("Pass")
f1=Frame(root, bg='gray', bd=5)
f1.pack(side=RIGHT)

emailLabel  = Label(f1, text='Enter email',bg='gray')
emailEntry  = Entry(f1, width = 25,textvariable = e)
passLabel   = Label(f1, text='Enter password',bg='gray')
passEntry   = Entry(f1, width = 25,textvariable = p)
btn         = Button(f1, text='Отправить')

client.pack    ()
btn.pack       (side=BOTTOM)
passEntry.pack (side=BOTTOM)
passLabel.pack (side=BOTTOM)
emailEntry.pack(side=BOTTOM)
emailLabel.pack(side=BOTTOM)
'''

LogFrame = LoginationFrame(root)
LogFrame.pack()
buttonLog=Button(root,text='Hide',width=25, command =LogFrame.unshow )
buttonLog.pack()
buttonLog1=Button(root,text='Show',width=25, command =LogFrame.show )
buttonLog1.pack()

root.mainloop()
