import 'package:flutter/material.dart';
import 'ejercicios/pantalla_inicio.dart';

void main() {
  runApp(MiApp());
}

class MiApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Cliente SOAP Flutter',
      theme: ThemeData(primarySwatch: Colors.blue),
      home: PantallaInicio(),
    );
  }
}
