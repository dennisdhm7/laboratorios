import 'package:flutter/material.dart';
import 'saludo.dart';
import 'suma.dart';
import 'operaciones.dart';
import 'tabla1.dart';
import 'tabla2.dart';
import 'bisiesto.dart';

class PantallaInicio extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("Cliente Flutter - Web Services")),
      body: Padding(
        padding: const EdgeInsets.all(25),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            _boton(context, "Saludo", PaginaSaludo()),
            SizedBox(height: 10),
            _boton(context, "Suma", PaginaSuma()),
            SizedBox(height: 10),
            _boton(context, "Operaciones", PaginaOperaciones()),
            SizedBox(height: 10),
            _boton(context, "Tabla 1", PaginaTabla1()),
            SizedBox(height: 10),
            _boton(context, "Tabla 2", PaginaTabla2()),
            SizedBox(height: 10),
            _boton(context, "Año Bisiesto", PaginaBisiesto()),
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: () => Navigator.pop(context),
              style: ElevatedButton.styleFrom(backgroundColor: Colors.red),
              child: Text("Salir"),
            ),
          ],
        ),
      ),
    );
  }

  Widget _boton(BuildContext context, String titulo, Widget vista) {
    return ElevatedButton(
      onPressed: () {
        Navigator.push(context, MaterialPageRoute(builder: (_) => vista));
      },
      child: Text(titulo),
    );
  }
}
