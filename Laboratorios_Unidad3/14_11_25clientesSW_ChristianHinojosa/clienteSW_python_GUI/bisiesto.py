import tkinter as tk
from tkinter import ttk
from ws_config import client

def ventana_bisiesto():
    win = tk.Toplevel()
    win.title("Listar Años - Bisiestos / No Bisiestos / Ambos")
    win.geometry("450x500")

    tk.Label(win, text="Año Inicial:").pack(pady=5)
    entry_inicio = tk.Entry(win)
    entry_inicio.pack()

    tk.Label(win, text="Año Final:").pack(pady=5)
    entry_final = tk.Entry(win)
    entry_final.pack()

    tk.Label(win, text="Tipo de búsqueda:").pack(pady=5)
    combo = ttk.Combobox(win, values=["bisiestos", "nobisiestos", "ambos"])
    combo.current(0)
    combo.pack()

    text_resultado = tk.Text(win, width=50, height=15)
    text_resultado.pack(pady=15)

    def consultar():
        try:
            inicio = int(entry_inicio.get())
            fin = int(entry_final.get())
            tipo = combo.get()

            resultado = client.service.ListarAñosTipos(inicio, fin, tipo)

            text_resultado.delete("1.0", tk.END)
            for item in resultado:
                text_resultado.insert(tk.END, item + "\n")

        except Exception as e:
            text_resultado.insert(tk.END, f"Error: {e}")

    tk.Button(win, text="Consultar", command=consultar).pack(pady=10)
