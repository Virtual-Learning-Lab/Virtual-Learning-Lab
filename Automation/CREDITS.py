import tkinter
from tkinter import *
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
        self.add_btn = Button(self.window, text='Add CREDITS: ', command=self.add)
        self.add_btn.grid(row=3, column=1)

    def add(self):
        self.here = sys.path[0]
        self.CREDITS_md_path = open(os.path.join(self.here, "DUMMY_CREDITS.md")) #open(sys.path[0] + '/../CREDITS.md')
        self.CREDITS_txt_path = open(os.path.join(self.here, "DUMMY_CREDITS.txt")) #open(sys.path[0] + '/../Virtual Learning Lab program/Assets/Scenes/Resources/CREDITS.txt')

        self.title_format = "## "
        self.name_format = "[]"
        self.link_format = "()"

        print(self.CREDITS_md_path.read())
        print(self.CREDITS_txt_path.read())

        self.title_value = self.title_inp.get()
        self.name_value = self.name_inp.get()
        self.link_value = self.link_inp.get()

        self.CREDITS_md_path.write()

    def remove(self):
        pass

if __name__ == "__main__":
    window = Tk()
    main(window)
    window.mainloop()
