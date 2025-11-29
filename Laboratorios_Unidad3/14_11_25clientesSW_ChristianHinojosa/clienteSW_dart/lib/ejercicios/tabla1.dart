import 'package:flutter/material.dart';
import '../soap_ws.dart';

class PaginaTabla1 extends StatefulWidget {
  @override
  State<PaginaTabla1> createState() => _PaginaTabla1State();
}

class _PaginaTabla1State extends State<PaginaTabla1> {
  final numero = TextEditingController();
  String resultado = "";

  Future<void> obtenerTabla1() async {
    final xml =
        """
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <Tabla1 xmlns="http://tempuri.org/">
      <numero>${numero.text}</numero>
    </Tabla1>
  </soap:Body>
</soap:Envelope>
""";

    final resp = await SoapService.callSoap("http://tempuri.org/Tabla1", xml);

    final ini = resp.indexOf("<Tabla1Result>") + 14;
    final fin = resp.indexOf("</Tabla1Result>");

    setState(() {
      resultado = resp.substring(ini, fin).replaceAll("\\r\\n", "\n");
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("Tabla1 - WS")),
      body: Padding(
        padding: EdgeInsets.all(20),
        child: Column(
          children: [
            TextField(
              controller: numero,
              decoration: InputDecoration(labelText: "Número"),
              keyboardType: TextInputType.number,
            ),
            SizedBox(height: 20),
            ElevatedButton(onPressed: obtenerTabla1, child: Text("Generar")),
            SizedBox(height: 20),
            Text("Resultado:"),
            SizedBox(height: 10),
            Expanded(child: SingleChildScrollView(child: Text(resultado))),
          ],
        ),
      ),
    );
  }
}
