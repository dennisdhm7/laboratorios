import 'package:flutter/material.dart';
import '../soap_ws.dart';

class PaginaBisiesto extends StatefulWidget {
  @override
  State<PaginaBisiesto> createState() => _PaginaBisiestoState();
}

class _PaginaBisiestoState extends State<PaginaBisiesto> {
  final inicio = TextEditingController();
  final fin = TextEditingController();

  String tipo = "bisiestos";
  List<String> resultados = [];

  Future<void> obtenerAnios() async {
    final xml =
        """
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <ListarAñosTipos xmlns="http://tempuri.org/">
      <anioInicial>${inicio.text}</anioInicial>
      <anioFinal>${fin.text}</anioFinal>
      <tipo>$tipo</tipo>
    </ListarAñosTipos>
  </soap:Body>
</soap:Envelope>
""";

    final resp = await SoapService.callSoap(
      "http://tempuri.org/ListarAñosTipos",
      xml,
    );

    final regex = RegExp(r"<string>(.*?)<\/string>");
    final temp = regex.allMatches(resp).map((e) => e.group(1)!).toList();

    setState(() {
      resultados = temp;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("Año Bisiesto - WS")),
      body: Padding(
        padding: EdgeInsets.all(20),
        child: Column(
          children: [
            TextField(
              controller: inicio,
              decoration: InputDecoration(labelText: "Año Inicial"),
              keyboardType: TextInputType.number,
            ),
            TextField(
              controller: fin,
              decoration: InputDecoration(labelText: "Año Final"),
              keyboardType: TextInputType.number,
            ),
            DropdownButton(
              value: tipo,
              items: const [
                DropdownMenuItem(value: "bisiestos", child: Text("Bisiestos")),
                DropdownMenuItem(
                  value: "nobisiestos",
                  child: Text("No Bisiestos"),
                ),
                DropdownMenuItem(value: "ambos", child: Text("Ambos")),
              ],
              onChanged: (v) => setState(() => tipo = v!),
            ),
            ElevatedButton(onPressed: obtenerAnios, child: Text("Consultar")),
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
