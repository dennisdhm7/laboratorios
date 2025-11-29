import tkinter as tk
from ws_config import client

def ventana_tabla2():
    win = tk.Toplevel()
    win.title("Tabla2")
    win.geometry("350x400")

    tk.Label(win, text="Ingrese número:").pack()
    num = tk.Entry(win)
    num.pack()

    text_resultado = tk.Text(win, width=35, height=15)
    text_resultado.pack(pady=10)

    def ejecutar():
        try:
            a = int(num.get())
            r = client.service.Tabla2(a)

            text_resultado.delete("1.0", tk.END)
            text_resultado.insert(tk.END, "\n".join(r))

        except Exception as e:
            text_resultado.insert(tk.END, f"Error: {e}")

    tk.Button(win, text="Generar Tabla", command=ejecutar).pack(pady=10)
