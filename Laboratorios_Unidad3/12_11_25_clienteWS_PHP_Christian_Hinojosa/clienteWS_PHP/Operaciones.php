<?php
    $clientephp = new SoapClient("http://localhost:56791/WebServices/WS_Server.asmx?WSDL");
    
    if (isset($_POST['n1']) && isset($_POST['n2'])) {

        $params = new stdClass();
        $params->tipo = $_POST['operacion'];
        $params->num1 = $_POST['n1'];
        $params->num2 = $_POST['n2'];

        $tipo = $_POST['operacion'];
        $num1 = $_POST['n1'];
        $num2 = $_POST['n2'];

        $Resultado = $clientephp->Operaciones($params)->OperacionesResult;
    }
?>
<html>
    <title>Operaciones de Web Services</title>
    <body>
        <center>
            <h1>Operaciones de Web Services</h1>

            <form name="frmOperaciones" action="" method="post">
                <label>Ingrese numero 1:</label>
                <input type="number" name="n1"/>
                <br>
                <label>Ingrese numero 2:</label>
                <input type="number" name="n2"/>
                <br><br>

                <label>Operación:</label>
                <select name="operacion">
                    <option value="S">Suma</option>
                    <option value="R">Resta</option>
                    <option value="M">Multiplicación</option>
                    <option value="D">División</option>
                </select>

                <br><br>
                <input type="submit" value="Calcular" />
                <br><br>

                <?php
                    if (isset($Resultado)) {
                        echo "Número 1: $num1<br><br>";
                        echo "Número 2: $num2<br><br>";
                        echo "Operación: $tipo<br><br>";
                        echo "Resultado de la Operación: $Resultado";
                    }
                ?>
            </form>
        </center>
    </body>
</html>
