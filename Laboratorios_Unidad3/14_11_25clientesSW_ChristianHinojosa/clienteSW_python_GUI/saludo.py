import tkinter as tk
from tkinter import messagebox
from ws_config import client

def ventana_saludo():
    win = tk.Toplevel()
    win.title("Método Saludos")
    win.geometry("350x250")

    tk.Label(win, text="Ejecutar Saludos", font=("Arial", 14)).pack(pady=10)

    text_resultado = tk.Text(win, width=35, height=5)
    text_resultado.pack(pady=10)

    def ejecutar():
        try:
            r = client.service.Saludos()
            text_resultado.delete("1.0", tk.END)
            text_resultado.insert(tk.END, r)
        except Exception as e:
            text_resultado.insert(tk.END, f"Error: {e}")

    tk.Button(win, text="Llamar Saludos()", width=25, command=ejecutar).pack(pady=10)
