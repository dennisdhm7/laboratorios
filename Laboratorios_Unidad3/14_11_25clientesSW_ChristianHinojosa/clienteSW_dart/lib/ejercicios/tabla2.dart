import 'package:flutter/material.dart';
import '../soap_ws.dart';

class PaginaTabla2 extends StatefulWidget {
  @override
  State<PaginaTabla2> createState() => _PaginaTabla2State();
}

class _PaginaTabla2State extends State<PaginaTabla2> {
  final numero = TextEditingController();
  List<String> resultados = [];

  Future<void> obtenerTabla2() async {
    final xml =
        """
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <Tabla2 xmlns="http://tempuri.org/">
      <numero>${numero.text}</numero>
    </Tabla2>
  </soap:Body>
</soap:Envelope>
""";

    final resp = await SoapService.callSoap("http://tempuri.org/Tabla2", xml);

    final regex = RegExp(r"<string>(.*?)<\/string>");
    final temp = regex.allMatches(resp).map((e) => e.group(1)!).toList();

    setState(() {
      resultados = temp;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("Tabla2 - WS")),
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
            ElevatedButton(onPressed: obtenerTabla2, child: Text("Generar")),
            SizedBox(height: 20),
            Expanded(
              child: ListView.builder(
                itemCount: resultados.length,
                itemBuilder: (_, i) => Text(resultados[i]),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
