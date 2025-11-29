<?php
    $clientephp = new SoapClient("http://localhost:56791/WebServices/WS_Server.asmx?WSDL");

    $Resultado = [];
    $numero = "";

    if (isset($_POST['num'])) {

        $numero = $_POST['num'];

        $params = new stdClass();
        $params->numero = $numero;

        $respuesta = $clientephp->Tabla2($params);

        if (isset($respuesta->Tabla2Result->string)) {
            $Resultado = $respuesta->Tabla2Result->string;
        }
    }
?>
<html>
    <title>Tabla de Multiplicar de Web Services Web Services</title>
    <body>
        <center>
            <h1>Tabla de Multiplicar de Web Services</h1>
            <br><br>

            <form method="post">
                <label>Ingrese número:</label>
                <input type="number" name="num" required />
                <br><br>

                <input type="submit" value="Calcular" />
                <br><br>
            </form>

            <?php
                if (!empty($Resultado)) {
                    echo "Número: $numero<br><br>";
                    foreach ($Resultado as $fila) {
                        echo $fila . "<br>";
                    }
                }
            ?>
        </center>
    </body>
</html>
