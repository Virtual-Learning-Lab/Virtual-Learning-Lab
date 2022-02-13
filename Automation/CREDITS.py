import tkinter
from tkinter import *
from tkinter import messagebox
import sys
import os

class main:
    def __init__(self, window):
        self.window = window
        self.window.title('CREDITS')

        self.title_lbl = Label(self.window, text='Title: ')
        self.title_lbl.grid(row=0, column=0)
        self.title_inp = Entry(self.window)
        self.title_inp.grid(row=0, column=1)

        self.name_lbl = Label(self.window, text='Name: ')
        self.name_lbl.grid(row=1, column=0)
        self.name_inp = Entry(self.window)
        self.name_inp.grid(row=1, column=1)

        self.link_lbl = Label(self.window, text='Link: ')
        self.link_lbl.grid(row=2, column=0)
        self.link_inp = Entry(self.window)
        self.link_inp.grid(row=2, column=1)

        self.remove_btn = Button(self.window, text='Remove CREDITS: ')
        self.remove_btn.grid(row=3, column=0)
        self.add_btn = Button(self.window, text='Add CREDITS: ', command=lambda addremove="add": self.check_content(addremove))
        self.add_btn.grid(row=3, column=1)

    def check_content(self, addremove):
        if self.title_inp.get() == "":
            messagebox.showerror('Title entry is empty', 'The title entry is empty. Please give a title.')
            return
        elif self.name_inp.get() == "":
            messagebox.showerror('Name entry is empty', 'The name entry is empty. Please give a name.')
            return
        elif self.link_inp.get() == "":
            messagebox.showerror('Link entry is empty', 'The link entry is empty. Please give a link.')
            return

        if addremove == "add":
            self.add()
        elif addremove == "remove":
            self.remove()
        else:
            messagebox.showerror('Command not found', f'Command: {addremove} is not found')


    def add(self):
        self.here = sys.path[0]
        self.CREDITS_md_file = open(os.path.join(self.here, "DUMMY_CREDITS.md")) #open(sys.path[0] + '/../CREDITS.md')
        self.CREDITS_txt_file = open(os.path.join(self.here, "DUMMY_CREDITS.txt")) #open(sys.path[0] + '/../Virtual Learning Lab program/Assets/Scenes/Resources/CREDITS.txt')

        self.title_format = "## "
        self.name_format = "[]"
        self.link_format = "()"

        self.CREDITS_md_content = self.CREDITS_md_file.read()
        self.CREDITS_txt_content = self.CREDITS_txt_file.read()

        self.title_value = self.title_inp.get()
        self.name_value = self.name_inp.get()
        self.link_value = self.link_inp.get()

        if self.CREDITS_md_content == "":
            #print("file is empty")
            #self.CREDITS_md_file.write()
            pass


        self.CREDITS_md_file.close()
        self.CREDITS_txt_file.close()

    def remove(self):
        pass

if __name__ == "__main__":
    window = Tk()
    main(window)
    window.mainloop()
