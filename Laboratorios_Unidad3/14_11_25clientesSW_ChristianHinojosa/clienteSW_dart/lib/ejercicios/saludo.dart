import 'package:flutter/material.dart';
import '../soap_ws.dart';

class PaginaSaludo extends StatefulWidget {
  @override
  State<PaginaSaludo> createState() => _PaginaSaludoState();
}

class _PaginaSaludoState extends State<PaginaSaludo> {
  String resultado = "";

  Future<void> llamarSaludos() async {
    const xml = """
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <Saludos xmlns="http://tempuri.org/" />
  </soap:Body>
</soap:Envelope>
""";

    final resp = await SoapService.callSoap("http://tempuri.org/Saludos", xml);

    final ini = resp.indexOf("<SaludosResult>") + 15;
    final fin = resp.indexOf("</SaludosResult>");

    setState(() {
      resultado = resp.substring(ini, fin);
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("Saludo - WS")),
      body: Padding(
        padding: const EdgeInsets.all(20),
        child: Column(
          children: [
            ElevatedButton(
              onPressed: llamarSaludos,
              child: Text("Consultar Saludo"),
            ),
            SizedBox(height: 20),
            Text("Resultado:", style: TextStyle(fontWeight: FontWeight.bold)),
            SizedBox(height: 10),
            Text(resultado),
          ],
        ),
      ),
    );
  }
}
