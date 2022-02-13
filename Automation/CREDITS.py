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

        self.remove_btn = Button(self.window, text='Remove CREDITS: ', command=lambda addremove="remove": self.check_content(addremove))
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
        errors = None
        try:
            self.here = sys.path[0]
            self.CREDITS_md_file_read = open(os.path.join(self.here, "DUMMY_CREDITS.md"), 'r') #open(sys.path[0] + '/../CREDITS.md')
            self.CREDITS_txt_file_read = open(os.path.join(self.here, "DUMMY_CREDITS.txt"), 'r') #open(sys.path[0] + '/../Virtual Learning Lab program/Assets/Scenes/Resources/CREDITS.txt')

            self.title_format = "## "
            self.name_format = "[]"
            self.link_format = "()"

            self.CREDITS_md_content = self.CREDITS_md_file_read.read()
            self.CREDITS_txt_content = self.CREDITS_txt_file_read.read()

            self.CREDITS_md_file_write = open(os.path.join(self.here, "DUMMY_CREDITS.md"), 'w') #open(sys.path[0] + '/../CREDITS.md')
            self.CREDITS_txt_file_write = open(os.path.join(self.here, "DUMMY_CREDITS.txt"), 'w') #open(sys.path[0] + '/../Virtual Learning Lab program/Assets/Scenes/Resources/CREDITS.txt')

            self.title_value = self.title_inp.get()
            self.name_value = self.name_inp.get()
            self.link_value = self.link_inp.get()

            print(self.CREDITS_md_content)

            if self.CREDITS_md_content == "":
                #print("file is empty")
                self.CREDITS_md_file_write.write(f"{self.title_format}{self.title_value}\n")
                self.CREDITS_md_file_write.write(f"{self.name_format[0]}{self.name_value}{self.name_format[1]}{self.link_format[0]}{self.link_value}{self.link_format[1]}  ")
            else:
                error = True


            self.CREDITS_md_file_read.close()
            self.CREDITS_txt_file_read.close()
            self.CREDITS_md_file_write.close()
            self.CREDITS_txt_file_write.close()

            self.title_inp.delete(0, 'end')
            self.name_inp.delete(0, 'end')
            self.link_inp.delete(0, 'end')
        except Exception as e:
            messagebox.showerror('Error', f'Error: {e}')
            errors = True

        if errors == None:
            messagebox.showinfo('Success', 'Credits added successfully')
        else:
            messagebox.showinfo('Error', 'Something went wrong while generating the credits.')

    def remove(self):
        pass

if __name__ == "__main__":
    window = Tk()
    main(window)
    window.mainloop()
