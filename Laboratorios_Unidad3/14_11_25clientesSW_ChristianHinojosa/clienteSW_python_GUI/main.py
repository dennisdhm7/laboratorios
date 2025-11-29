import tkinter as tk
from saludo import ventana_saludo
from suma import ventana_suma
from operaciones import ventana_operaciones
from tabla1 import ventana_tabla1
from tabla2 import ventana_tabla2
from bisiesto import ventana_bisiesto

root = tk.Tk()
root.title("Python Tkinter - WS")
root.geometry("400x500")

titulo = tk.Label(root, text="Python GUI - WS", font=("Arial", 16))
titulo.pack(pady=20)

tk.Button(root, text="1. Saludos", width=30, command=ventana_saludo).pack(pady=5)
tk.Button(root, text="2. Suma", width=30, command=ventana_suma).pack(pady=5)
tk.Button(root, text="3. Operaciones", width=30, command=ventana_operaciones).pack(pady=5)
tk.Button(root, text="4. Tabla1", width=30, command=ventana_tabla1).pack(pady=5)
tk.Button(root, text="5. Tabla2", width=30, command=ventana_tabla2).pack(pady=5)
tk.Button(root, text="6. Año Bisiesto", width=30, command=ventana_bisiesto).pack(pady=5)

tk.Button(root, text="Salir", width=30, command=root.quit).pack(pady=20)

root.mainloop()
