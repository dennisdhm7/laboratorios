import 'package:flutter/material.dart';
import '../soap_ws.dart';

class PaginaOperaciones extends StatefulWidget {
  @override
  State<PaginaOperaciones> createState() => _PaginaOperacionesState();
}

class _PaginaOperacionesState extends State<PaginaOperaciones> {
  final n1 = TextEditingController();
  final n2 = TextEditingController();

  String tipo = "S"; // S = Suma, R = Resta, M = Multiplicación, D = División
  String resultado = "";

  Future<void> ejecutarOperacion() async {
    final xml =
        """
        <soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
          <soap:Body>
            <Operaciones xmlns="http://tempuri.org/">
              <tipo>$tipo</tipo>
              <num1>${n1.text}</num1>
              <num2>${n2.text}</num2>
            </Operaciones>
          </soap:Body>
        </soap:Envelope>
        """;

    final resp = await SoapService.callSoap(
      "http://tempuri.org/Operaciones",
      xml,
    );

    final reg = RegExp(r"<OperacionesResult>(.*?)<\/OperacionesResult>");
    final match = reg.firstMatch(resp);

    setState(() {
      resultado = match != null ? match.group(1)! : "Error leyendo resultado";
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("Operaciones - WS")),
      body: Padding(
        padding: EdgeInsets.all(20),
        child: Column(
          children: [
            DropdownButton<String>(
              value: tipo,
              items: const [
                DropdownMenuItem(value: "S", child: Text("Suma")),
                DropdownMenuItem(value: "R", child: Text("Resta")),
                DropdownMenuItem(value: "M", child: Text("Multiplicación")),
                DropdownMenuItem(value: "D", child: Text("División")),
              ],
              onChanged: (v) => setState(() => tipo = v!),
            ),
            TextField(
              controller: n1,
              decoration: InputDecoration(labelText: "Número 1"),
              keyboardType: TextInputType.number,
            ),
            TextField(
              controller: n2,
              decoration: InputDecoration(labelText: "Número 2"),
              keyboardType: TextInputType.number,
            ),
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: ejecutarOperacion,
              child: Text("Calcular"),
            ),
            SizedBox(height: 20),
            Text("Resultado: $resultado"),
          ],
        ),
      ),
    );
  }
}
