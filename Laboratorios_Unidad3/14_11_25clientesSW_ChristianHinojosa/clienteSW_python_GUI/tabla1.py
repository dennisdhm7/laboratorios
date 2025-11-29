import tkinter as tk
from ws_config import client

def ventana_tabla1():
    win = tk.Toplevel()
    win.title("Tabla1")
    win.geometry("350x350")

    tk.Label(win, text="Ingrese número:").pack()
    num = tk.Entry(win)
    num.pack()

    text_resultado = tk.Text(win, width=35, height=12)
    text_resultado.pack(pady=10)

    def ejecutar():
        try:
            a = int(num.get())
            r = client.service.Tabla1(a)

            text_resultado.delete("1.0", tk.END)
            text_resultado.insert(tk.END, r)

        except Exception as e:
            text_resultado.insert(tk.END, f"Error: {e}")

    tk.Button(win, text="Generar Tabla", command=ejecutar).pack(pady=10)
