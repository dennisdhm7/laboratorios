import 'package:flutter/material.dart';
import '../soap_ws.dart';

class PaginaSuma extends StatefulWidget {
  @override
  State<PaginaSuma> createState() => _PaginaSumaState();
}

class _PaginaSumaState extends State<PaginaSuma> {
  final n1 = TextEditingController();
  final n2 = TextEditingController();

  String resultado = "";

  Future<void> calcularSuma() async {
    final xml =
        """
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <Suma xmlns="http://tempuri.org/">
      <num1>${n1.text}</num1>
      <num2>${n2.text}</num2>
    </Suma>
  </soap:Body>
</soap:Envelope>
""";

    final resp = await SoapService.callSoap("http://tempuri.org/Suma", xml);

    final ini = resp.indexOf("<SumaResult>") + 12;
    final fin = resp.indexOf("</SumaResult>");

    setState(() {
      resultado = resp.substring(ini, fin);
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("Suma - WS")),
      body: Padding(
        padding: const EdgeInsets.all(20),
        child: Column(
          children: [
            TextField(
              controller: n1,
              decoration: InputDecoration(labelText: "Número 1"),
            ),
            TextField(
              controller: n2,
              decoration: InputDecoration(labelText: "Número 2"),
            ),
            SizedBox(height: 20),
            ElevatedButton(onPressed: calcularSuma, child: Text("Calcular")),
            SizedBox(height: 20),
            Text("Resultado: $resultado"),
          ],
        ),
      ),
    );
  }
}
