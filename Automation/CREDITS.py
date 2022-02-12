import tkinter
from tkinter import *
import sys

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
        self.CREDITS_md_path = open(sys.path[0] + '/../CREDITS.md')
        self.CREDITS_txt_path = open(sys.path[0] + '/../CREDITS.md')
        print(f.read())

    def remove(self):
        pass

if __name__ == "__main__":
    window = Tk()
    main(window)
    window.mainloop()
