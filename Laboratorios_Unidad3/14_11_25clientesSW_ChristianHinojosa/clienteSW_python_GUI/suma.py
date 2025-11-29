import tkinter as tk
from ws_config import client

def ventana_suma():
    win = tk.Toplevel()
    win.title("Suma")
    win.geometry("350x300")

    tk.Label(win, text="Número 1:").pack()
    n1 = tk.Entry(win)
    n1.pack()

    tk.Label(win, text="Número 2:").pack()
    n2 = tk.Entry(win)
    n2.pack()

    text_resultado = tk.Text(win, width=35, height=5)
    text_resultado.pack(pady=10)

    def calcular():
        try:
            a = float(n1.get())
            b = float(n2.get())
            r = client.service.Suma(a, b)

            text_resultado.delete("1.0", tk.END)
            text_resultado.insert(tk.END, f"Resultado = {r}")

        except Exception as e:
            text_resultado.insert(tk.END, f"Error: {e}")

    tk.Button(win, text="Calcular", command=calcular).pack(pady=10)
