import tkinter
from tkinter import *

class main:
    def __init__(self, window):
        self.window = window
        self.window.title('CREDITS')

        self.title_lbl = Label(self.window, text='Title: ')
        self.title_lbl.grid(row=0, column=0)
        self.title_inp = Entry(self.window)
        self.title_inp.grid(row=0, column=1)

        self.name_lbl = Label(self.window, text="Name: ")
        self.name_lbl.grid(row=1, column=0)
        self.name_inp = Entry(self.window)
        self.name_inp.grid(row=1, column=1)

if __name__ == "__main__":
    window = Tk()
    main(window)
    window.mainloop()
