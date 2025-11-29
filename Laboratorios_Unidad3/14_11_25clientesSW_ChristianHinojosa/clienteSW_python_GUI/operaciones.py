import tkinter as tk
from tkinter import ttk
from ws_config import client

def ventana_operaciones():
    win = tk.Toplevel()
    win.title("Operaciones")
    win.geometry("360x350")

    tk.Label(win, text="Número 1:").pack()
    n1 = tk.Entry(win)
    n1.pack()

    tk.Label(win, text="Número 2:").pack()
    n2 = tk.Entry(win)
    n2.pack()

    tk.Label(win, text="Seleccione operación:").pack()
    combo = ttk.Combobox(win, values=["Suma", "Resta", "Multiplicación", "División"])
    combo.current(0)
    combo.pack()

    text_resultado = tk.Text(win, width=35, height=5)
    text_resultado.pack(pady=10)

    def ejecutar():
        try:
            a = float(n1.get())
            b = float(n2.get())

            oper = combo.get()

            if oper == "Suma":
                tipo = "S"
            elif oper == "Resta":
                tipo = "R"
            elif oper == "Multiplicación":
                tipo = "M"
            else:
                tipo = "D"

            r = client.service.Operaciones(tipo, a, b)

            text_resultado.delete("1.0", tk.END)
            text_resultado.insert(tk.END, f"Resultado = {r}")

        except Exception as e:
            text_resultado.insert(tk.END, f"Error: {e}")

    tk.Button(win, text="Calcular", command=ejecutar).pack(pady=10)
