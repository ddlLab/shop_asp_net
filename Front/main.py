from tkinter import *

from core_frame import CoreFrame

root = Tk()
root.title("Main title")
coreFrame = CoreFrame(root)
coreFrame.pack()

root.mainloop()