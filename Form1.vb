Imports DLL_PerceptronMulticapa.Data
Imports DLL_PerceptronMulticapa.Network
Imports DLL_PerceptronMulticapa.Layers

Imports DLL_PerceptronMulticapa

Public Class Form1


    Dim Network_LearningRate_Initial As Double = 0.0000001
    Dim Network As MultilayerPerceptron
    Dim Training As New List(Of Training1)

    Private SymbolFont As Font = New Font("Symbol", 9, FontStyle.Bold)

    Dim ctThread_Test As Threading.Thread
    Dim ctThread As Threading.Thread
    Dim result As Integer = 0
    Event Event_Mensage(ByVal EventNumber As String)

    Dim Entrenamiento As String = "Open"

    Private Sub Form_IaMercado3Dias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ComboBox_CerebrosLista.Items.Clear()

            For Each Cerebro As String In Class_CerebrosArchivosXML.ObtenerCerebros
                ComboBox_CerebrosLista.Items.Add(Cerebro)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Delegate Sub DelegateChart1Value(ByVal Chart1Value() As String)
    Private Sub Chart1_ValuePrediccion(ByVal Mensaje() As String)

        If Me.Chart1.InvokeRequired Then
            Dim d As New DelegateChart1Value(AddressOf Chart1_ValuePrediccion)
            Call Chart1.Invoke(d, New Object() {Mensaje})
        Else
            'RichTextBox1.Text &= Environment.NewLine & Mensaje
            'RichTextBox1.Lines.Last
            'RichTextBox1.SelectedText = RichTextBox1.Lines.Last
            Chart1.Series("Series_Prediccion").Points.AddXY(Mensaje(1), Mensaje(2))
            If Mensaje(0) = 0 Then
                Chart1.Series("Series_Prediccion").Points(Chart1.Series("Series_Prediccion").Points.Count - 1).Color = Color.White
            ElseIf Mensaje(0) = 1 Then
                Chart1.Series("Series_Prediccion").Points(Chart1.Series("Series_Prediccion").Points.Count - 1).Color = Color.Red
            ElseIf Mensaje(0) = 2 Then
                Chart1.Series("Series_Prediccion").Points(Chart1.Series("Series_Prediccion").Points.Count - 1).Color = Color.Azure
            ElseIf Mensaje(0) = 3 Then
                Chart1.Series("Series_Prediccion").Points(Chart1.Series("Series_Prediccion").Points.Count - 1).Color = Color.FloralWhite
            ElseIf Mensaje(0) = 4 Then
                Chart1.Series("Series_Prediccion").Points(Chart1.Series("Series_Prediccion").Points.Count - 1).Color = Color.Indigo
            ElseIf Mensaje(0) = 5 Then
                Chart1.Series("Series_Prediccion").Points(Chart1.Series("Series_Prediccion").Points.Count - 1).Color = Color.Black
            Else

                Mensaje(0) = 0
            End If

            'RichTextBox1.Select(RichTextBox1.TextLength - 2, RichTextBox1.TextLength - 1)
            ' RichTextBox1.Select(RichTextBox1.TextLength - 1, RichTextBox1.TextLength)

            'RichTextBox1.ScrollToCaret()
            'RichTextBox1.Height = 212
        End If
    End Sub
    Private Sub Chart1_ValueValores(ByVal Mensaje() As String)

        If Me.Chart1.InvokeRequired Then
            Dim d As New DelegateChart1Value(AddressOf Chart1_ValueValores)
            Call Chart1.Invoke(d, New Object() {Mensaje})
        Else
            'RichTextBox1.Text &= Environment.NewLine & Mensaje
            'RichTextBox1.Lines.Last
            'RichTextBox1.SelectedText = RichTextBox1.Lines.Last
            Try
                Chart1.Series("Series_Open").Points.AddXY(Mensaje(0), Mensaje(0), Mensaje(0), Mensaje(0), Mensaje(0), Mensaje(0), Mensaje(0))
            Catch ex As Exception
                Dim aaa = 0
            End Try

            If Mensaje(0) = 0 Then
                Chart1.Series("Series_Open").Points(Chart1.Series("Series_Open").Points.Count - 1).Color = Color.White
            ElseIf Mensaje(0) = 1 Then
                Chart1.Series("Series_Open").Points(Chart1.Series("Series_Open").Points.Count - 1).Color = Color.Red
            ElseIf Mensaje(0) = 2 Then
                Chart1.Series("Series_Open").Points(Chart1.Series("Series_Open").Points.Count - 1).Color = Color.Azure
            ElseIf Mensaje(0) = 3 Then
                Chart1.Series("Series_Open").Points(Chart1.Series("Series_Open").Points.Count - 1).Color = Color.FloralWhite
            ElseIf Mensaje(0) = 4 Then
                Chart1.Series("Series_Open").Points(Chart1.Series("Series_Open").Points.Count - 1).Color = Color.Indigo
            Else

                Mensaje(0) = 0
            End If

            'RichTextBox1.Select(RichTextBox1.TextLength - 2, RichTextBox1.TextLength - 1)
            ' RichTextBox1.Select(RichTextBox1.TextLength - 1, RichTextBox1.TextLength)

            'RichTextBox1.ScrollToCaret()
            'RichTextBox1.Height = 212
        End If
    End Sub

    Private Sub Chart1_Reset(ByVal Mensaje() As String)
        Try
            If Me.Chart1.InvokeRequired Then
                Dim d As New DelegateChart1Value(AddressOf Chart1_Reset)
                Call Chart1.Invoke(d, New Object() {Mensaje})
            Else
                If Mensaje(0) = 0 Then
                    Chart1.Series("Series_Prediccion").Points.Clear()
                Else
                    Chart1.Series("Series_Open").Points.Clear()
                End If


            End If
        Catch ex As Exception

        End Try

    End Sub

    Delegate Sub DelegateMensaje(ByVal MSG As String)
    Private Sub msg(ByVal Mensaje As String)
        If Me.RichTextBox1.InvokeRequired Then
            Dim d As New DelegateMensaje(AddressOf msg)
            Call RichTextBox1.Invoke(d, New Object() {Mensaje})
        Else
            RichTextBox1.Text &= Environment.NewLine & Mensaje
            'RichTextBox1.Lines.Last
            'RichTextBox1.SelectedText = RichTextBox1.Lines.Last

            'RichTextBox1.Select(RichTextBox1.TextLength - 2, RichTextBox1.TextLength - 1)
            RichTextBox1.Select(RichTextBox1.TextLength - 1, RichTextBox1.TextLength)

            RichTextBox1.ScrollToCaret()
            'RichTextBox1.Height = 212
        End If
    End Sub

#Region "Generar red "

    Private Sub Button_GenerarRed_Click(sender As Object, e As EventArgs) Handles Button_GenerarRed.Click
        Try
            RichTextBox1.Text = ""
            Dim standard As New Randoms.Standard(New DLL_PerceptronMulticapa.Utilities.Range(-1, 1), DateTime.Now.Millisecond)
            Dim num_hidden_A() As Integer
            If TextBox_Capas.Text = 1 Then
                num_hidden_A = {TextBox_Neuronas.Text}
            ElseIf TextBox_Capas.Text = 1 Then
                num_hidden_A = {TextBox_Neuronas.Text, TextBox_Neuronas.Text}

            Else
                num_hidden_A = {TextBox_Neuronas.Text, TextBox_Neuronas.Text, TextBox_Neuronas.Text}
            End If

            If ListBox_Neuronas.Items.Count > 0 Then
                Dim num_hidden_B(ListBox_Neuronas.Items.Count - 1) As Integer

                For indice As Integer = 0 To ListBox_Neuronas.Items.Count - 1
                    If ListBox_Neuronas.Items.Item(indice) <> 0 Then
                        num_hidden_B.SetValue(CInt(ListBox_Neuronas.Items.Item(indice)), indice)
                    End If

                Next
                Network = New MultilayerPerceptron(TextBox_ConexionesNumero.Text, num_hidden_B, TextBox_Salidas.Text, Replace(TextBox_AlfaEntrenamiento.Text, ".", ","), Replace(TextBox_Momento.Text, ".", ","), standard, New Activation.BipolarSigmoid(0.5))
            Else
                Network = New MultilayerPerceptron(TextBox_ConexionesNumero.Text, num_hidden_A, TextBox_Salidas.Text, Replace(TextBox_AlfaEntrenamiento.Text, ".", ","), Replace(TextBox_Momento.Text, ".", ","), standard, New Activation.BipolarSigmoid(0.5))

            End If

        Catch ex As Exception

        End Try
        Try


            Dim g As Graphics = PictureBox_ImagenRed.CreateGraphics

            g.Clear(Color.White)

            Dim bitMap As New Bitmap(PictureBox_ImagenRed.Width, PictureBox_ImagenRed.Height)
            PictureBox_ImagenRed.Image = bitMap
            Dim gg = Graphics.FromImage(bitMap)
            'Dim BitmapGraficos As New Bitmap(PictureBox_ImagenRed.Image)

            Red_Paint(PictureBox_ImagenRed, gg)

            'Dim bitMap2 As Bitmap = Bitmap.FromHbitmap(gg.GetHdc())
            'PictureBox_ImagenRed.Image = bitMap2

            ' Graphics g = PictureBox1.CreateGraphics();          
            'Bitmap Bitmap = Bitmap.FromHbitmap(g.GetHdc());
            'Bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            ' PictureBox_ImagenRed.Image = GraficoPerceptron.

            'Dim g As Graphics = Red_Paint(PictureBox_ImagenRed, PictureBox_ImagenRed.CreateGraphics) 'PictureBox1.CreateGraphics()

            'PictureBox_ImagenRed.Image = bitMap2
            'bitMap.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg)
        Catch ex As Exception
        End Try
        Try

        Catch ex As Exception

        End Try
    End Sub

    'Dim GraficoPerceptron As Graphics
    Private Function Red_Paint(sender As PictureBox, ByVal g As Graphics) As Graphics ' Handles MyBase.Paint
        Try
            sender.Invalidate()

            Dim PenLinea1 As New Pen(Color.Black)
            ' Draw the neural network
            Dim input As Integer = Network.InputLayer.Neurons.Count
            Dim layers As Integer = Network.Layers.Count - 2
            Dim hidden As Integer = Network.Layers.Item(1).Neurons.Count
            Dim output As Integer = Network.OutputLayer.Neurons.Count
            ' Dim g As Graphics = e.Graphics
            ' draw input values
            Dim i1 As Integer = 0
            Do While (i1 < input)
                'g.DrawString(Me.inputs(CurrentCount, i1).ToString, Font, Brushes.Navy, (((ClientRectangle.Width - (input * 50)) / 2) + ((i1 * 50) + 15)), 5, New StringFormat)
                i1 = (i1 + 1)
            Loop

            ' g.DrawString(CurrentCount.ToString, Font, Brushes.Green, (ClientRectangle.Width - 20), 5, New StringFormat)
            ' draw input layer
            Dim i2 As Integer = 0
            Do While (i2 < input)
                ' center around client
                Dim x1 As Integer = (((TabPage2.Width - (input * 50)) / 2) + (i2 * 50))
                g.DrawEllipse(PenLinea1, x1, 20, 30, 30)
                g.DrawString("S", SymbolFont, Brushes.Green, (((sender.Width - (input * 50)) / 2) + ((i2 * 50) + 5)), (20 + 5))
                i2 = (i2 + 1)
            Loop

            ' draw hidden layer
            Dim i3 As Integer = 0
            Do While (i3 < hidden)
                Dim x1 As Integer = (((TabPage2.Width - (hidden * 50)) / 2) + (i3 * 50))
                g.DrawEllipse(Pens.Black, x1, 70, 30, 30)
                g.DrawString("S", SymbolFont, Brushes.Green, ((((sender.Width - (hidden * 50)) + 5) / 2) + (i3 * 50)), (70 + 5))
                i3 = (i3 + 1)
            Loop

            ' draw output layer
            Dim i4 As Integer = 0
            Do While (i4 < output)
                Dim x1 As Integer = (((TabPage2.Width - (output * 50)) / 2) + (i4 * 50))
                g.DrawEllipse(Pens.Black, x1, 120, 30, 30)
                g.DrawString("S", SymbolFont, Brushes.Green, (((sender.Width - (output * 50)) / 2) + ((i4 * 50) + 10)), (120 + 5))
                i4 = (i4 + 1)
            Loop
            Try
                '' draw output values
                'Dim i5 As Integer = 0
                'Do While (i5 < output)
                '    If SimulationStarted = False Then 'If SimulationStarted Then
                '        g.DrawString(CurrentOutputValue(i5), Font, Brushes.Purple, (((ClientRectangle.Width - (output * 50)) / 2) + ((i5 * 50) + 15)), 160, New StringFormat)
                '    Else
                '        g.DrawString(Me.outputs(CurrentCount, i5).ToString, Font, Brushes.Navy, (((ClientRectangle.Width - (output * 50)) / 2) + ((i5 * 50) + 15)), 160, New StringFormat)
                '    End If

                '    i5 = (i5 + 1)
                'Loop
            Catch ex As Exception

            End Try


            ' now connect each input layer to the hidden layer
            Dim i6 As Integer = 0
            Do While (i6 < input)
                Dim j As Integer = 0
                Do While (j < hidden)
                    Dim x1 As Integer = (((TabPage2.Width - (input * 50)) / 2) + ((i6 * 50) + 15))
                    Dim x2 As Integer = 50
                    Dim y1 As Integer = (((TabPage2.Width - (hidden * 50)) / 2) + ((j * 50) + 15))
                    Dim y2 As Integer = 70
                    g.DrawLine(Pens.Coral, x1, 50, y2, 70)
                    j = (j + 1)
                Loop

                i6 = (i6 + 1)
            Loop

            ' now connect each hidden layer to the output layer
            Dim i7 As Integer = 0
            Do While (i7 < hidden)
                Dim j As Integer = 0
                Do While (j < output)
                    Dim x1 As Integer = (((TabPage2.Width - (hidden * 50)) / 2) + ((i7 * 50) + 15))
                    Dim x2 As Integer = 100
                    Dim y1 As Integer = (((TabPage2.Width - (output * 50)) / 2) + ((j * 50) + 15))
                    Dim y2 As Integer = 120
                    g.DrawLine(Pens.Coral, x1, 100, y1, 120)
                    j = (j + 1)
                Loop

                i7 = (i7 + 1)
            Loop
            'g.Flush()

            'sender.Refresh()
            'PictureBox_ImagenRed.Update()
            'PictureBox_ImagenRed.Show()
            'PictureBox1.Refresh()
            'PictureBox_ImagenRed.Image = 
            'Panel_ImagenRed.()
            'sender.DrawToBitmap(sender., g)
            'GraficoPerceptron = g

        Catch ex As Exception

        End Try
        Return g
    End Function

    Private Sub Button_AñadirCapa_Click(sender As Object, e As EventArgs) Handles Button_AñadirCapa.Click
        Try
            ListBox_Neuronas.Items.Add(TextBox_Neuronas.Text)
            TextBox_Capas.Text = ListBox_Neuronas.Items.Count
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_QuitarCapa_Click(sender As Object, e As EventArgs) Handles Button_QuitarCapa.Click
        Try
            ListBox_Neuronas.Items.Remove(ListBox_Neuronas.SelectedItem)
            TextBox_Capas.Text = ListBox_Neuronas.Items.Count
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_Guardar_Click(sender As Object, e As EventArgs) Handles Button_Guardar.Click


        Try
            Dim RutaAchivo As String = Class_Configuraciones.RutaDatos_Obtener().ToString & "\Cerebros\" & TextBox_GuardarNombre.Text.Trim
            If My.Computer.FileSystem.FileExists(RutaAchivo) = False Then
                Dim textoXML As String = "<?xml version=""1.0"" encoding=""iso-8859-15"" ?><body><tabla_Datos> </tabla_Datos></body>"



                My.Computer.FileSystem.WriteAllText(RutaAchivo, textoXML, False)
            End If



            If Class_CerebrosArchivosXML.ExisteNombre(TextBox_GuardarNombre.Text.Trim, TextBox_GuardarNombre.Text.Trim) Then
                Dim MsgResponse As MsgBoxResult
                MsgResponse = MsgBox(" El Id. ya se encuentra en la lista " & vbCr & " ¿ desea agregarlo ? ", MsgBoxStyle.YesNo)
                If MsgResponse = MsgBoxResult.Yes Then

                Else
                    Exit Sub
                End If
            End If


            Dim ContadorRegistros As Integer = Class_Contadores.ObtenerWhereContador("CuentaCerebros").Cuenta + 1
            If Class_CerebrosArchivosXML.ExisteId(ContadorRegistros, TextBox_GuardarNombre.Text.Trim) Then
                Dim PosicionTexto As Integer = RichTextBox1.Text.Length
                RichTextBox1.Text &= "Ya existe  = " & ContadorRegistros & vbCrLf
                RichTextBox1.Select(PosicionTexto, RichTextBox1.Text.Length)
                'MsgBox("El id del contador ya existe" & vbCr & "puede modificarlo para poder agregar nuevos socios", MsgBoxStyle.Information)
                'Exit Sub
            End If



            Dim Texto As String = ""
            Dim Capa_Count As Integer = 0
            Dim nodos_Count As Integer = 0
            Dim CerebroLista As ClassArchivo_Cerebro = Network.Get_Pesos()
            CerebroLista.Id = ContadorRegistros + 1
            CerebroLista.Nombre = TextBox_GuardarNombre.Text
            CerebroLista.Delta = Network.Bias.Primed 'Network.Bias.WeightToBias.Value
            CerebroLista.TotalError = Network.TotalError

            'CerebroLista.Delt = Network.ActivationFunction
            For Each Capas As ClassArchivo_Cerebro.ClassArchivo_Capa In CerebroLista.Capas
                Capa_Count += 1
                For Each Nodos As ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona In Capas.Nodos
                    nodos_Count += 1
                    Texto &= " Capa:" & Capa_Count & "  nodo:" & nodos_Count & "  Peso:" & Nodos.Peso & "  Prima:" & Network.Bias.ErrorDelta & vbCrLf
                Next
            Next
            RichTextBox1.Text = Texto
            Class_CerebrosArchivosXML.InsertarRejistro(CerebroLista, RutaAchivo)
            Class_Contadores.ModificarRejistro("CuentaCerebros", ContadorRegistros + 1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'Try
        '    ComboBox_CerebrosLista.Items.Clear()

        '    For Each Cerebro As ClassArchivo_Cerebro In Class_CerebrosXML.ObtenerTodos
        '        ComboBox_CerebrosLista.Items.Add(Cerebro.Nombre)
        '    Next
        'Catch ex As Exception

        'End Try
        Try
            ComboBox_CerebrosLista.Items.Clear()

            For Each Cerebro As String In Class_CerebrosArchivosXML.ObtenerCerebros
                ComboBox_CerebrosLista.Items.Add(Cerebro)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_Cargar_Click(sender As Object, e As EventArgs) Handles Button_Cargar.Click
        Try

            Dim standard As New Randoms.Standard(New Utilities.Range(-1, 1), DateTime.Now.Millisecond)

            Dim CerebroEstructura As ClassArchivo_Cerebro = Class_CerebrosArchivosXML.ObtenerWhereNombre(ComboBox_CerebrosLista.Text, ComboBox_CerebrosLista.Text)

            Dim num_hidden() As Integer

            If CerebroEstructura.Capas.Count = 3 Then
                num_hidden = {CerebroEstructura.Capas.Item(1).Nodos.Count}
            ElseIf CerebroEstructura.Capas.Count = 4 Then
                num_hidden = {CerebroEstructura.Capas.Item(1).Nodos.Count, CerebroEstructura.Capas.Item(2).Nodos.Count}

            Else
                num_hidden = {CerebroEstructura.Capas.Item(1).Nodos.Count, CerebroEstructura.Capas.Item(2).Nodos.Count, CerebroEstructura.Capas.Item(3).Nodos.Count}
            End If


            Network = New MultilayerPerceptron(CerebroEstructura.Capas.Item(0).Nodos.Count, num_hidden, CerebroEstructura.Capas.Item(CerebroEstructura.Capas.Count - 1).Nodos.Count, Replace(TextBox_AlfaEntrenamiento.Text, ".", ","), Replace(TextBox_Momento.Text, ".", ","), standard, New Activation.BipolarSigmoid(0.5))

            TextBox_ConexionesNumero.Text = CerebroEstructura.Capas.First.Nodos.Count
            TextBox_Capas.Text = CerebroEstructura.Capas.Count - 2
            TextBox_Salidas.Text = CerebroEstructura.Capas.Last.Nodos.Count
            TextBox_Neuronas.Text = CerebroEstructura.Capas.Item(1).Nodos.Count


            Network.Set_Pesos(CerebroEstructura)



            Dim Capa_Count As Integer = 0
            Dim nodos_Count As Integer = 0
            Dim Texto As String = ""
            For Each Capas As ClassArchivo_Cerebro.ClassArchivo_Capa In CerebroEstructura.Capas
                Capa_Count += 1
                For Each Nodos As ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona In Capas.Nodos
                    nodos_Count += 1
                    Texto &= " Capa:" & Capa_Count & "  nodo:" & nodos_Count & "  Peso:" & Nodos.Peso & "  PesoPrev:" & Nodos.Peso & "  Prima:" & Nodos.Primed & vbCrLf
                Next
            Next
            RichTextBox1.Text = Texto

        Catch ex As Exception

        End Try

        Try
            ListBox_Neuronas.Items.Clear()

            For Each CapaOculta In Network.HiddenLayers

                ListBox_Neuronas.Items.Add(CapaOculta.Neurons.Count)
            Next

        Catch ex As Exception

        End Try
        Try


            Dim g As Graphics = PictureBox_ImagenRed.CreateGraphics

            g.Clear(Color.White)

            Dim bitMap As New Bitmap(PictureBox_ImagenRed.Width, PictureBox_ImagenRed.Height)
            PictureBox_ImagenRed.Image = bitMap
            Dim gg = Graphics.FromImage(bitMap)

            Red_Paint(PictureBox_ImagenRed, gg)


        Catch ex As Exception
        End Try
    End Sub

    Private Sub ComboBox_CerebrosLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_CerebrosLista.SelectedIndexChanged
        Try
            ' TextBox_GuardarNombre.Text = ComboBox_CerebrosLista.Text
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Entrenemiento y test"

    Private Sub Label_LearningRate_Click(sender As Object, e As EventArgs) Handles Label_LearningRate.Click
        Try
            Dim ProductoNeuronas As Double = 1
            For indice As Integer = 0 To Network.Layers.Count - 1
                ProductoNeuronas *= Network.Layers.Item(indice).Neurons.Count
            Next

            TextBox_AlfaEntrenamiento.Text = (1 / ProductoNeuronas)
        Catch ex As Exception

        End Try
    End Sub




    Private Sub ComboBox_Entrenamiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Entrenamiento.SelectedIndexChanged

    End Sub

    Private Sub Button_EntrenamientoCSV_Click(sender As Object, e As EventArgs) Handles Button_EntrenamientoCSV.Click
        Try
            Dim DatosEntrenamiento As New Class_ArchivoEntrenamiento
            DatosEntrenamiento.data = Training
            DatosEntrenamiento.epochs = TextBox_EpocasEntrenamiento.Text
            DatosEntrenamiento.min_error = Replace(TextBox_FactorActivacion.Text, ".", ",")
            ' Dim Training As New List(Of Training)
            Network.LearningRate = Replace(TextBox_AlfaEntrenamiento.Text, ".", ",")

            Network.Momentum = Replace(TextBox_Momento.Text.Trim, ".", ",")
            RichTextBox1.Text = ""
            ctThread = New Threading.Thread(AddressOf EntrenamientoCSV)
            AddHandler Event_Mensage, AddressOf msg
            ctThread.Start(DatosEntrenamiento)
            Threading.Thread.Sleep(300)


        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Private Sub EntrenamientoCSV(datos As Class_ArchivoEntrenamiento)
        Try



            Dim datosTest As New List(Of Testing)
            Dim bitMap As New Bitmap(PictureBox_ImagenRed.Width, PictureBox_ImagenRed.Height)
            Dim GraficosBMP1 As New Bitmap(bitMap)
            Dim GraficosBMP2 As New Bitmap(bitMap)



            Dim Desede As Integer = 0
            Dim Asta As Integer = 119
            Dim Archivos() As String = {"BTC-EUR_2019To2021_EUR.csv", "IBM_1986To2021.csv", "ETH-EUR_2019To2021_EUR.csv", "ETH-USD_2019To2021.csv", "EUR=X_2003To2021.csv", "LTC-EUR_2019To2021_EUR.csv", "PHM.MC_2016To2021_USD.csv", "KO_1962To2021.csv", "AMZN_1997To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "INTC_1980To2021.csv", "PYPL_2015To2021.csv"}


            Dim listaArchivos = FileIO.FileSystem.GetFiles(My.Application.Info.DirectoryPath & "\Datos\")
            ReDim Archivos(listaArchivos.Count)
            For indice As Integer = 0 To listaArchivos.Count - 1
                Dim Archivo As New System.IO.FileInfo(listaArchivos(indice))
                Archivos.SetValue(Archivo.Name, indice)
            Next

            '{"BTC-EUR_2019To2021_EUR.csv", "IBM_1986To2021.csv", "ETH-EUR_2019To2021_EUR.csv", "ETH-USD_2019To2021.csv", "BTC-EUR_2019To2021_EUR.csv", "EUR=X_2003To2021.csv", "LTC-EUR_2019To2021_EUR.csv", "BTC-EUR_2019To2021_EUR.csv", "PHM.MC_2016To2021_USD.csv", "KO_1962To2021.csv", "AMZN_1997To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "INTC_1980To2021.csv", "PYPL_2015To2021.csv"}
            Dim IndiceArchivos As Int16 = 0
            Try

                result = 1000

                While Not result


                    Dim CSV As New Class_CSV_Read
                    If IndiceArchivos > Archivos.Count - 1 Then
                        IndiceArchivos = 0
                        Desede = 0
                        Asta = 119
                        msg("")
                    End If
                    msg("")
                    msg("lee archivo =" & Archivos(IndiceArchivos))
                    Dim Dateado As List(Of Class_ArchivoTrading.Archivo_Trading) = CSV.Read_list(Archivos(IndiceArchivos))
                    Training.Clear()
                    datosTest.Clear()
                    msg("  registros =" & Dateado.Count)
                    Dim indiceDateado As Integer = 0
                    Dim EpocasAsta As Integer = 0

                    If Asta < Dateado.Count - 1 Then
                        ' Dim resto As Double = Math.Ab(Dateado.Count, 120)
                        EpocasAsta = (Dateado.Count - 2) - Asta
                    Else
                        EpocasAsta = Dateado.Count - 1
                    End If

                    For indiceEpocas As Integer = Desede To EpocasAsta
                        indiceDateado = indiceEpocas
                        Dim Entradas(119) As Double
                        For indice As Integer = 0 To 119 Step 6
                            Try


                                Dim valorOpen As Double = CDbl(Dateado.Item(indiceDateado).Open) / 200000

                                Try
                                    If CDbl(Dateado.Item(indiceDateado).Open) < CDbl(Dateado.Item(indiceDateado - 1).Open) Then
                                        valorOpen = (CDbl(Dateado.Item(indiceDateado).Open) - (CDbl(Dateado.Item(indiceDateado - 1).Open) - CDbl(Dateado.Item(indiceDateado).Open))) / 200000
                                    ElseIf CDbl(Dateado.Item(indiceDateado).Open) > CDbl(Dateado.Item(indiceDateado - 1).Open) Then
                                        valorOpen = (CDbl(Dateado.Item(indiceDateado).Open) + (CDbl(Dateado.Item(indiceDateado).Open) - CDbl(Dateado.Item(indiceDateado - 1).Open))) / 200000
                                    End If
                                Catch ex As Exception

                                End Try
                                Entradas.SetValue(valorOpen, indice)
                                'If indiceDateado < PictureBox_ImagenRed.Width Then
                                '    GraficosBMP1.SetPixel(indiceDateado, valorOpen * 120, Color.Black)
                                'End If
                                Dim valorHigh As Double = CDbl(Dateado.Item(indiceDateado).High) / 200000
                                Entradas.SetValue(valorHigh, indice + 1)
                                Dim valorLow As Double = CDbl(Dateado.Item(indiceDateado).Low) / 200000
                                Entradas.SetValue(valorLow, indice + 2)
                                Dim valorClose As Double = CDbl(Dateado.Item(indiceDateado).Close) / 200000
                                Entradas.SetValue(valorClose, indice + 3)
                                Dim valorAdjClose As Double = CDbl(Dateado.Item(indiceDateado).AdjClose) / 200000
                                Entradas.SetValue(valorAdjClose, indice + 4)
                                Dim valorVolume As Double = CDbl(Dateado.Item(indiceDateado).Volume) / 250000000000
                                Entradas.SetValue(valorVolume, indice + 5)
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try
                            indiceDateado += 1
                            If indiceDateado > Dateado.Count - 1 Then
                                indiceDateado = 0
                                Asta = 119
                                Desede = 0
                                IndiceArchivos = +1

                                If indice = 119 Then
                                    msg("ok file")
                                    Desede = 0
                                    Asta = 119
                                    GoTo 1001
                                Else
                                    msg("no end read, ok file")
                                    GoTo 1111
                                End If

                            End If
                            If IndiceArchivos > Archivos.Count - 1 Then
                                IndiceArchivos = 0
                                Desede = 0
                                Asta = 119
                                msg("")
                                GoTo 1111
                            End If
                        Next

                        'Dim Salidas() As Decimal = {CDec(Dateado.Item(indiceDateado).Open)}
1001:                   Try

                            Dim DatoSalida() As Double = New Double(0) {}
                            Select Case Entrenamiento
                                Case "Open"
                                    DatoSalida(0) = CDbl(Dateado.Item(indiceDateado).Open) / 200000
                                Case "Max"
                                    DatoSalida(0) = CDbl(Dateado.Item(indiceDateado).High) / 200000
                                Case "Min"
                                    DatoSalida(0) = CDbl(Dateado.Item(indiceDateado).Low) / 200000
                                Case "Close"
                                    DatoSalida(0) = CDbl(Dateado.Item(indiceDateado).Close) / 200000
                                Case "Volume"
                                    DatoSalida(0) = CDbl(Dateado.Item(indiceDateado).Volume) / 250000000000
                                Case Else
                                    DatoSalida(0) = CDbl(Dateado.Item(indiceDateado).Open) / 200000
                            End Select




                            Training.Add(New Training1(Entradas, DatoSalida))
                            datosTest.Add(New Testing(Entradas))
                            Asta = Asta + 1
                            Desede = Desede + 1
                        Catch ex As Exception
                            'MsgBox(ex.Message)
                        End Try


                    Next

1111:

                    IndiceArchivos += 1
                    'Img(GraficosBMP1)

                    Desede = 0
                    Asta = 119

                    Network.Train(Training, datos.epochs, Network.LearningRate)



                    msg("error=" & Network.TotalError)
                    Try
                        msg("error/rows=" & Network.TotalError / Dateado.Count)
                    Catch ex As Exception

                    End Try

                    Console.WriteLine(String.Format("Total error on correctly predicting training set: {0}", Network.TotalError))
                    Console.ReadLine()


                    Try

                        Dim Resultados As New List(Of Double)
                        'Resultados = Network.OutputLayer.ExtractOutputs()
                        Resultados = Network.TestList(datosTest)
                        For indice1 As Integer = 1 To PictureBox2.Size.Width - 1
                            Dim Valor As Double = (Resultados(indice1) * 60) + 60
                            If Valor < 1 Then
                                GraficosBMP2.SetPixel(indiceDateado, 1, Color.Blue)
                            ElseIf Valor > 119 Then
                                GraficosBMP2.SetPixel(indiceDateado, 119, Color.Red)
                            Else
                                GraficosBMP2.SetPixel(indiceDateado, Valor, Color.Black)
                            End If

                        Next

                    Catch ex As Exception

                    End Try


                    result -= 1
                    Threading.Thread.Sleep(100)
                End While


                msg("end Thread")

            Catch ex As Exception

            End Try


        Catch ex As Exception

        End Try

    End Sub


    Private Sub Prueba(datos As List(Of Testing))
        Try


            'result = 1000

            'While Not result

            Dim Resultados As New List(Of Double)
            Resultados = Network.TestList(datos)
            msg(Network.TotalError)

            'Console.WriteLine(String.Format("Total error on correctly predicting training set: {0}", Network.TotalError))
            'Console.ReadLine()
            'result -= 1
            'End While
            Dim IndiceTotal As Integer = 0
            Dim Graficos1 As New Bitmap(PictureBox1.Image)
            Dim Graficos2 As New Bitmap(PictureBox2.Image)
            Dim PosX As Decimal = 0
            Dim PosY As Decimal = 0
            For indice1 As Integer = 1 To PictureBox2.Size.Height - 1
                For incice2 As Integer = 1 To PictureBox2.Size.Width - 1
                    'Dim Pixel As Color = Graficos.GetPixel(Incice2, indice)
                    'Dim IntensidadPixel As Decimal = (CInt(Pixel.A) + CInt(Pixel.G) + CInt(Pixel.R)) / 765
                    'PosX = Incice2 / 64
                    'PosY = indice / 64

                    Dim Pixel As Color = New Color
                    Dim brillo As Integer = 0
                    Try
                        brillo = IndiceTotal / 120 'CInt(datos.Item(incice1).Input.Item(incice2) 'Math.Abs(256 - Math.Abs(Resultados.Item(IndiceTotal)) * 766)
                    Catch ex As Exception

                    End Try

                    If brillo < 0 Then
                        Dim pixelColor_Set1 As Color = Color.FromArgb(100, 55, 55, 255)
                        Graficos2.SetPixel(incice2, indice1, pixelColor_Set1)
                    ElseIf brillo > 255 Then
                        Dim pixelColor_Set1 As Color = Color.FromArgb(100, 255, 5, 5)
                        Graficos2.SetPixel(incice2, indice1, pixelColor_Set1)

                    Else
                        Dim pixelColor_Set1 As Color = Color.FromArgb(255, brillo, brillo, brillo)
                        Graficos2.SetPixel(incice2, indice1, pixelColor_Set1)
                    End If



                    'Pixel.ToArgb(brillo, brillo, brillo, brillo)

                    IndiceTotal += 1
                Next
                'Img2(Graficos)

            Next

            PictureBox2.Image = Graficos2


            Threading.Thread.Sleep(100)


            msg("ok")
            Dim pixelColor_Set1a As Color = Color.FromArgb(255, 255, 255, 255)
            For indice1 As Integer = 1 To PictureBox1.Size.Height - 1
                For incice2 As Integer = 1 To PictureBox1.Size.Width - 1
                    Graficos1.SetPixel(incice2, indice1, pixelColor_Set1a)
                Next
            Next

            IndiceTotal = 0


            For incice2 As Integer = 1 To PictureBox1.Size.Width - 1

                For indice1 As Integer = 1 To PictureBox1.Size.Height - 1

                    If IndiceTotal > Training.Count - 1 Then

                        Exit Sub
                    End If
                    Dim Pixel As Color = New Color

                    Dim brillo As Integer
                    brillo = Training.Item(incice2).Entrada.Item(indice1) * 255
                    If brillo > 255 Then
                        brillo = brillo / 90 'brillo / Math.Pow(9, brillo.ToString.Length)

                    End If


                    If brillo < 0 Then
                        Dim pixelColor_Set1 As Color = Color.FromArgb(255, 55, 255, 55)
                        Graficos1.SetPixel(incice2, indice1, pixelColor_Set1)
                    ElseIf brillo > 255 Then
                        Dim pixelColor_Set1 As Color = Color.FromArgb(255, 255, 5, 5)
                        Graficos1.SetPixel(incice2, indice1, pixelColor_Set1)
                    Else
                        Dim pixelColor_Set1 As Color = Color.FromArgb(255, brillo, brillo, brillo)
                        Graficos1.SetPixel(incice2, indice1, pixelColor_Set1)
                    End If



                    'Pixel.ToArgb(brillo, brillo, brillo, brillo)

                    IndiceTotal += 1
                Next

            Next


            msg(".")

        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Friend Sub Tester_Inicio()
        Try
            Chart1.Series("Series_Open").Points.Clear()
            Chart1.Series("Series_Prediccion").Points.Clear()
            Dim Test As List(Of Testing) = New List(Of Testing)
            'Dim Test1 As Testing = New Testing({0, 0})
            Try

                Dim Archivos() As String '= {"BTC-EUR_2019To2021_EUR.csv", "IBM_1986To2021.csv", "ETH-EUR_2019To2021_EUR.csv", "ETH-USD_2019To2021.csv", "EUR=X_2003To2021.csv", "LTC-EUR_2019To2021_EUR.csv", "PHM.MC_2016To2021_USD.csv", "KO_1962To2021.csv", "AMZN_1997To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "INTC_1980To2021.csv", "PYPL_2015To2021.csv"}
                '{"BTC-EUR_2019To2021_EUR.csv", "IBM_1986To2021.csv", "ETH-EUR_2019To2021_EUR.csv", "EUR=X_2003To2021.csv", "LTC-EUR_2019To2021_EUR.csv", "PHM.MC_2016To2021_USD.csv", "KO_1962To2021.csv"}
                Dim listaArchivos = FileIO.FileSystem.GetFiles(My.Application.Info.DirectoryPath & "\Datos\")
                ReDim Archivos(listaArchivos.Count)
                For indice As Integer = 0 To listaArchivos.Count - 1
                    Dim Archivo As New System.IO.FileInfo(listaArchivos(indice))
                    Archivos.SetValue(Archivo.Name, indice)
                Next


                Dim IndiceArchivos As Int16 = TextBox_TestArchivoIndice.Text
                Dim IndiceRegistro As Integer = 0

                Dim CSV As New Class_CSV_Read
                If IndiceArchivos > Archivos.Count - 1 Then
                    IndiceArchivos = 0
                    msg("")
                End If
                Dim Dateado As List(Of Class_ArchivoTrading.Archivo_Trading) = CSV.Read_list(Archivos(IndiceArchivos))


                Dim bitMap As New Bitmap(PictureBox_ImagenRed.Width, PictureBox_ImagenRed.Height)
                PictureBox1.Image = bitMap

                Dim GraficosBMP As New Bitmap(PictureBox1.Image)


                Dim desde As Integer = 0
                Dim asta As Integer = 112

                Dim Entradas(119) As Double


                For indice As Integer = 0 To 114 Step 6

                    Try

                        Dim valorOpen As Double = CDbl(Dateado.Item(IndiceRegistro).Open) / 200000
                        Entradas.SetValue(valorOpen, indice)


                        Dim valor As Double = ((valorOpen * 120) * TextBox_ZoomEntradas.Text) - TextBox_ZoomEntradas.Text
                        If valor < 1 Then
                            valor = 1
                        ElseIf valor > 119 Then
                            valor = 119
                        End If


                        Dim valorHigh As Double = CDbl(Dateado.Item(IndiceRegistro).High) / 200000
                        Entradas.SetValue(valorHigh, indice + 1)
                        Dim valorLow As Double = CDbl(Dateado.Item(IndiceRegistro).Low) / 200000
                        Entradas.SetValue(valorLow, indice + 2)
                        Dim valorClose As Double = CDbl(Dateado.Item(IndiceRegistro).Close) / 200000
                        Entradas.SetValue(valorClose, indice + 3)
                        Dim valorAdjClose As Double = CDbl(Dateado.Item(IndiceRegistro).AdjClose) / 200000
                        Entradas.SetValue(valorAdjClose, indice + 4)
                        Dim valorVolume As Double = CDbl(Dateado.Item(IndiceRegistro).Volume) / 250000000000
                        Entradas.SetValue(valorVolume, indice + 5)


                        Chart1.Series("Series_Open").Points.AddXY(Dateado.Item(IndiceRegistro).Fecha, Dateado.Item(IndiceRegistro).Low, Dateado.Item(IndiceRegistro).High, Dateado.Item(IndiceRegistro).Close, Dateado.Item(IndiceRegistro).Open, Dateado.Item(IndiceRegistro).AdjClose, Dateado.Item(IndiceRegistro).Volume / 10000000)
                        If Dateado.Item(IndiceRegistro).Close > Dateado.Item(IndiceRegistro).Open Then
                            Chart1.Series("Series_Open").Points(Chart1.Series("Series_Open").Points.Count - 1).Color = Color.Green
                        ElseIf Dateado.Item(IndiceRegistro).Close < Dateado.Item(IndiceRegistro).Open Then
                            Chart1.Series("Series_Open").Points(Chart1.Series("Series_Open").Points.Count - 1).Color = Color.Red
                        End If
                        Chart1_ValuePrediccion({0, Dateado.Item(IndiceRegistro).Fecha, 0, 0.1})
                        Chart1.Series("Series_Prediccion").Points(Chart1.Series("Series_Prediccion").Points.Count - 1).Color = Color.White
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                    If IndiceArchivos > Archivos.Count - 1 Then
                        IndiceArchivos = 0
                        msg("")

                    End If
                    IndiceRegistro += 1
                Next



                asta += 1
                desde += 1

                'Next
                Test.Add(New Testing(Entradas))

                PictureBox1.Image = GraficosBMP


            Catch ex As Exception

            End Try

            Network.LearningRate = Replace(TextBox_AlfaEntrenamiento.Text, ".", ",")


            RichTextBox1.Text = ""
            ctThread_Test = New Threading.Thread(AddressOf PruebaCSV)
            AddHandler Event_Mensage, AddressOf msg
            ctThread_Test.Start(Test)
            Threading.Thread.Sleep(30)


        Catch ex As Exception
            msg("0x0 " & ex.Message)
        End Try
    End Sub

    Private Sub TextBox_TestArchivoIndice_TextChanged(sender As Object, e As EventArgs) Handles TextBox_TestArchivoIndice.TextChanged
        Try
            Dim Archivos() As String '= {"BTC-EUR_2019To2021_EUR.csv", "IBM_1986To2021.csv", "ETH-EUR_2019To2021_EUR.csv", "ETH-USD_2019To2021.csv", "EUR=X_2003To2021.csv", "LTC-EUR_2019To2021_EUR.csv", "PHM.MC_2016To2021_USD.csv", "KO_1962To2021.csv", "AMZN_1997To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "INTC_1980To2021.csv", "PYPL_2015To2021.csv"}
            '{"BTC-EUR_2019To2021_EUR.csv", "IBM_1986To2021.csv", "ETH-EUR_2019To2021_EUR.csv", "EUR=X_2003To2021.csv", "LTC-EUR_2019To2021_EUR.csv", "PHM.MC_2016To2021_USD.csv", "KO_1962To2021.csv"}
            Dim listaArchivos = FileIO.FileSystem.GetFiles(My.Application.Info.DirectoryPath & "\Datos\")
            ReDim Archivos(listaArchivos.Count)
            For indice As Integer = 0 To listaArchivos.Count - 1
                Dim Archivo As New System.IO.FileInfo(listaArchivos(indice))
                Archivos.SetValue(Archivo.Name, indice)
            Next

            Dim CSV As New Class_CSV_Read
            Dim Dateado As List(Of Class_ArchivoTrading.Archivo_Trading) = CSV.Read_list(Archivos(TextBox_TestArchivoIndice.Text))

            TrackBar_TestCSV.Maximum = Dateado.Count

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TrackBar_TestCSV_Scroll(sender As Object, e As EventArgs) Handles TrackBar_TestCSV.Scroll
        Try
            TextBox_LoadCSV_Desde.Text = TrackBar_TestCSV.Value
            TextBox_LoadCSV_Asta.Text = TrackBar_TestCSV.Value + 120
            Tester_Inicio()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_TestCSV_Click(sender As Object, e As EventArgs) Handles Button_TestCSV.Click

    End Sub

    Private Sub PruebaCSV(datos As List(Of Testing))
        Try

            Dim Resultados As New List(Of Double)
            Resultados = Network.TestList(datos)
            msg(Network.TotalError)
            Try
                Chart1_ValuePrediccion({2, 120, Resultados.Item(0) * 200000})
                Chart1_ValuePrediccion({3, 121, Resultados.Item(0) * 200000})
            Catch ex As Exception

            End Try

            Dim IndiceTotal As Integer = 0
            'Dim Graficos1 As New Bitmap(PictureBox1.Image)
            Dim Graficos2 As New Bitmap(PictureBox2.Size.Width, PictureBox2.Size.Height)

            Dim PosX As Decimal = 0
            Dim PosY As Decimal = 0
            For indice1 As Integer = 1 To PictureBox2.Size.Height - 1
                'Chart1_Value({indice1, Resultados(indice1) * 200000})
                ' Chart1.Series("Series_Prediccion").Points.AddXY(indice1, Resultados(indice1) * 200000)
                Dim Pixel As Color = New Color

                Dim PosicionAltura As Integer = 0
                Try
                    PosicionAltura = (Resultados(indice1) * 60) + 60
                Catch ex As Exception

                End Try

                If PosicionAltura < 0 Then
                    Dim pixelColor_Set1 As Color = Color.FromArgb(100, 55, 55, 255)
                    Graficos2.SetPixel(indice1, 1, pixelColor_Set1)
                ElseIf PosicionAltura >= 119 Then
                    Dim pixelColor_Set1 As Color = Color.FromArgb(100, 255, 5, 5)
                    Graficos2.SetPixel(indice1, 119, pixelColor_Set1)

                Else
                    Dim pixelColor_Set1 As Color = Color.FromArgb(255, 50, 50, 50)
                    Graficos2.SetPixel(indice1, PosicionAltura, pixelColor_Set1)
                End If



                IndiceTotal += 1


            Next

            PictureBox2.Image = Graficos2


            Threading.Thread.Sleep(100)

            'Img2(Graficos2)
            msg("ok")

            'Img(Graficos1)

            msg(".")

        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Private Sub Button_CargarDatosCSV_Click(sender As Object, e As EventArgs) Handles Button_CargarDatosCSV.Click

    End Sub

    Private Sub Button_EntrenamientoCsvVolumen_Click(sender As Object, e As EventArgs) Handles Button_EntrenamientoCsvVolumen.Click
        Try

            Entrenamiento = ComboBox_Entrenamiento.Text


            Dim DatosEntrenamiento As New Class_ArchivoEntrenamiento
            DatosEntrenamiento.data = Training
            DatosEntrenamiento.epochs = TextBox_EpocasEntrenamiento.Text
            DatosEntrenamiento.min_error = Replace(TextBox_FactorActivacion.Text, ".", ",")
            ' Dim Training As New List(Of Training)
            Network.LearningRate = Replace(TextBox_AlfaEntrenamiento.Text, ".", ",")

            Network.Momentum = Replace(TextBox_Momento.Text.Trim, ".", ",")
            RichTextBox1.Text = ""
            ctThread = New Threading.Thread(AddressOf EntrenamientoConcisoCSV)
            AddHandler Event_Mensage, AddressOf msg
            ctThread.Start(DatosEntrenamiento)
            Threading.Thread.Sleep(300)


        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Private Sub EntrenamientoConcisoCSV(datos As Class_ArchivoEntrenamiento)


        '        Dim datosTest As New List(Of Testing)
        '        Dim bitMap As New Bitmap(PictureBox_ImagenRed.Width, PictureBox_ImagenRed.Height)
        '        Dim GraficosBMP1 As New Bitmap(bitMap)
        '        Dim GraficosBMP2 As New Bitmap(bitMap)



        '        Dim Desede As Integer = 0
        '        Dim Asta As Integer = 119
        '        'Dim Archivos() As String = {"BTC-EUR_2019To2021_EUR.csv", "IBM_1986To2021.csv", "ETH-EUR_2019To2021_EUR.csv", "ETH-USD_2019To2021.csv", "EUR=X_2003To2021.csv", "LTC-EUR_2019To2021_EUR.csv", "PHM.MC_2016To2021_USD.csv", "KO_1962To2021.csv", "AMZN_1997To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "INTC_1980To2021.csv", "PYPL_2015To2021.csv"}

        '        'Dim Archivos() As String = {"BTC-USD_2014_2021.csv", "ETH-USD_2019To2021.csv", "BTC-USD_2014_2021.csv", "TRX-USD_2017To2021.csv"}
        '        Dim Archivos() As String = {"^IBEX_1993To2021.csv", "ETH-USD_2019To2021.csv", "TRX-USD_2017To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "BTC-USD_2014_2021.csv", "AMZN-USD_1997To2021.csv", "AAPL_1980To2021_USD.csv", "^IBEX_1993To2021.csv", "BTC-USD_2014_2021.csv", "LTC-USD_2014To2021.csv", "INTC-USD_1980To2021.csv", "AAPL_1980To2021_USD.csv", "BCH-USD_2017To2021.csv", "AMZN-USD_1997To2021.csv", "BTC-USD_2014_2021.csv", "BNB-USD_2017To2021.csv", "BTC-USD_2014_2021.csv", "ETH-USD_2019To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "BTC-USD_2014_2021.csv", "NVDA_1999To2021_USD.csv", "TRX-USD_2017To2021.csv", "LTC-USD_2014To2021.csv"}


        '        'Dim listaArchivos = FileIO.FileSystem.GetFiles(My.Application.Info.DirectoryPath & "\Datos\")
        '        'ReDim Archivos(listaArchivos.Count)
        '        'For indice As Integer = 0 To listaArchivos.Count - 1
        '        '    Dim Archivo As New System.IO.FileInfo(listaArchivos(indice))
        '        '    Archivos.SetValue(Archivo.Name, indice)
        '        'Next

        '        '{"BTC-EUR_2019To2021_EUR.csv", "IBM_1986To2021.csv", "ETH-EUR_2019To2021_EUR.csv", "ETH-USD_2019To2021.csv", "BTC-EUR_2019To2021_EUR.csv", "EUR=X_2003To2021.csv", "LTC-EUR_2019To2021_EUR.csv", "BTC-EUR_2019To2021_EUR.csv", "PHM.MC_2016To2021_USD.csv", "KO_1962To2021.csv", "AMZN_1997To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "INTC_1980To2021.csv", "PYPL_2015To2021.csv"}
        '        Dim IndiceArchivos As Int16 = 0
        '        Try

        '            result = 1000

        '            While Not result


        '                Dim CSV As New Class_CSV_Read
        '                If IndiceArchivos > Archivos.Count - 1 Then
        '                    IndiceArchivos = 0
        '                    Desede = 0
        '                    Asta = 119
        '                    msg("ciclo nuevo")
        '                End If
        '                Dim Dateado As List(Of Class_ArchivoTrading.Archivo_Trading) = CSV.Read_list(Archivos(IndiceArchivos))
        '                Training.Clear()
        '                datosTest.Clear()
        '                msg("")
        '                msg("lee archivo =" & Archivos(IndiceArchivos) & "  registros =" & Dateado.Count)
        '                Dim indiceDateado As Integer = 0
        '                Dim EpocasAsta As Integer = 0
        '                If Asta < Dateado.Count - 1 Then
        '                    ' Dim resto As Double = Math.Ab(Dateado.Count, 120)
        '                    EpocasAsta = (Dateado.Count - 2) - Asta
        '                Else
        '                    EpocasAsta = Dateado.Count - 1
        '                End If
        '                For indiceEpocas As Integer = Desede To EpocasAsta
        '                    indiceDateado = indiceEpocas
        '                    Dim Entradas(119) As Double
        '                    For indice As Integer = 0 To 119 Step 6
        '                        Try
        '                            Dim valorOpen As Double = CDbl(Dateado.Item(indiceDateado).Open) / 200000
        '                            Entradas.SetValue(valorOpen, indice)
        '                            If indiceDateado < PictureBox_ImagenRed.Width Then
        '                                GraficosBMP1.SetPixel(indiceDateado, valorOpen * 120, Color.Black)
        '                            End If
        '                            Dim valorHigh As Double = CDbl(Dateado.Item(indiceDateado).High) / 200000
        '                            Entradas.SetValue(valorHigh, indice + 1)
        '                            Dim valorLow As Double = CDbl(Dateado.Item(indiceDateado).Low) / 200000
        '                            Entradas.SetValue(valorLow, indice + 2)
        '                            Dim valorClose As Double = CDbl(Dateado.Item(indiceDateado).Close) / 200000
        '                            Entradas.SetValue(valorClose, indice + 3)
        '                            Dim valorAdjClose As Double = CDbl(Dateado.Item(indiceDateado).AdjClose) / 200000
        '                            Entradas.SetValue(valorAdjClose, indice + 4)
        '                            Dim valorVolume As Double = CDbl(Dateado.Item(indiceDateado).Volume) / 250000000000
        '                            Entradas.SetValue(valorVolume, indice + 5)
        '                        Catch ex As Exception
        '                            MsgBox(ex.Message)
        '                        End Try
        '                        indiceDateado += 1
        '                        If indiceDateado > Dateado.Count - 1 Then
        '                            indiceDateado = 0
        '                            Asta = 119
        '                            Desede = 0
        '                            IndiceArchivos = +1

        '                            If indice = 119 Then
        '                                msg("ok file")
        '                                Desede = 0
        '                                Asta = 119
        '                                GoTo 1001
        '                            Else
        '                                msg("no end read, ok file")
        '                                GoTo 1111
        '                            End If

        '                        End If
        '                        If IndiceArchivos > Archivos.Count - 1 Then
        '                            IndiceArchivos = 0
        '                            Desede = 0
        '                            Asta = 119
        '                            msg("")
        '                            GoTo 1111
        '                        End If
        '                    Next

        '                    'Dim Salidas() As Decimal = {CDec(Dateado.Item(indiceDateado).Open)}
        '1001:               Try



        '                        Dim DatoSalida As Double
        '                        Select Case Entrenamiento
        '                            Case "Open"

        '                                If CDbl(Dateado.Item(indiceDateado).Open) < CDbl(Dateado.Item(indiceDateado - 1).Open) Then
        '                                    DatoSalida = (CDbl(Dateado.Item(indiceDateado).Open) - (CDbl(Dateado.Item(indiceDateado).Open) / 100)) / 200000
        '                                ElseIf CDbl(Dateado.Item(indiceDateado).Open) > CDbl(Dateado.Item(indiceDateado - 1).Open) Then
        '                                    DatoSalida = (CDbl(Dateado.Item(indiceDateado).Open) + (CDbl(Dateado.Item(indiceDateado).Open) / 100)) / 200000
        '                                Else
        '                                    DatoSalida = CDbl(Dateado.Item(indiceDateado).Open) / 200000
        '                                End If


        '                                DatoSalida = CDbl(Dateado.Item(indiceDateado).Open) / 200000
        '                            Case "Max"
        '                                DatoSalida = CDbl(Dateado.Item(indiceDateado).High) / 200000
        '                            Case "Min"
        '                                DatoSalida = CDbl(Dateado.Item(indiceDateado).Low) / 200000
        '                            Case "Close"
        '                                DatoSalida = CDbl(Dateado.Item(indiceDateado).Close) / 200000
        '                            Case "Volume"
        '                                DatoSalida = CDbl(Dateado.Item(indiceDateado).Volume) / 250000000000
        '                            Case Else

        '                                Network.Train(Training, datos.epochs, Network.LearningRate)



        '                                msg("error=" & Network.TotalError)
        '                                Console.WriteLine(String.Format("Total error on correctly predicting training set: {0}", Network.TotalError))
        '                                Console.ReadLine()


        '                                Try

        '                        Dim Resultados As New List(Of Double)
        '                        'Resultados = Network.OutputLayer.ExtractOutputs()
        '                        Resultados = Network.TestList(datosTest)
        '                        For indice1 As Integer = 1 To PictureBox2.Size.Width - 1
        '                            Dim Valor As Double = (Resultados(indice1) * 60) + 60
        '                            If Valor < 1 Then
        '                                GraficosBMP2.SetPixel(indiceDateado, 1, Color.Blue)
        '                            ElseIf Valor > 119 Then
        '                                GraficosBMP2.SetPixel(indiceDateado, 119, Color.Red)
        '                            Else
        '                                GraficosBMP2.SetPixel(indiceDateado, Valor, Color.Black)
        '                            End If

        '                        Next

        '                    Catch ex As Exception

        '                    End Try


        '                    result -= 1
        '                    Threading.Thread.Sleep(1000)
        '            End While


        '            msg("end Thread")

        '        Catch ex As Exception

        '        End Try




    End Sub

    Private Sub Button_Entrenamiento2diasCSV_Click(sender As Object, e As EventArgs) ' Handles Button_Entrenamiento2diasSaltosCSV.Click
        Try

            Entrenamiento = ComboBox_Entrenamiento.Text

            Dim DatosEntrenamiento As New Class_ArchivoEntrenamiento
            DatosEntrenamiento.data = Training
            DatosEntrenamiento.epochs = TextBox_EpocasEntrenamiento.Text
            DatosEntrenamiento.min_error = Replace(TextBox_FactorActivacion.Text, ".", ",")
            ' Dim Training As New List(Of Training)
            Network.LearningRate = Replace(TextBox_AlfaEntrenamiento.Text, ".", ",")

            Network.Momentum = Replace(TextBox_Momento.Text.Trim, ".", ",")
            RichTextBox1.Text = ""
            ctThread = New Threading.Thread(AddressOf Entrenamiento2DiasCSV)
            AddHandler Event_Mensage, AddressOf msg
            ctThread.Start(DatosEntrenamiento)
            Threading.Thread.Sleep(300)


        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Private Sub Entrenamiento2DiasCSV(datos As Class_ArchivoEntrenamiento)

        Dim datosTest As New List(Of Testing)
        Dim bitMap As New Bitmap(PictureBox_ImagenRed.Width, PictureBox_ImagenRed.Height)
        Dim GraficosBMP1 As New Bitmap(bitMap)
        Dim GraficosBMP2 As New Bitmap(bitMap)

        Dim Desede As Integer = 0
        Dim Asta As Integer = 119
        Dim Archivos() As String = {"BTC-EUR_2019To2021_EUR.csv", "IBM_1986To2021.csv", "ETH-EUR_2019To2021_EUR.csv", "ETH-USD_2019To2021.csv", "EUR=X_2003To2021.csv", "LTC-EUR_2019To2021_EUR.csv", "PHM.MC_2016To2021_USD.csv", "KO_1962To2021.csv", "AMZN_1997To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "INTC_1980To2021.csv", "PYPL_2015To2021.csv"}

        Dim listaArchivos = FileIO.FileSystem.GetFiles(My.Application.Info.DirectoryPath & "\Datos\")
        ReDim Archivos(listaArchivos.Count)
        For indice As Integer = 0 To listaArchivos.Count - 1
            Dim Archivo As New System.IO.FileInfo(listaArchivos(indice))
            Archivos.SetValue(Archivo.Name, indice)
        Next

        '{"BTC-EUR_2019To2021_EUR.csv", "IBM_1986To2021.csv", "ETH-EUR_2019To2021_EUR.csv", "ETH-USD_2019To2021.csv", "BTC-EUR_2019To2021_EUR.csv", "EUR=X_2003To2021.csv", "LTC-EUR_2019To2021_EUR.csv", "BTC-EUR_2019To2021_EUR.csv", "PHM.MC_2016To2021_USD.csv", "KO_1962To2021.csv", "AMZN_1997To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "INTC_1980To2021.csv", "PYPL_2015To2021.csv"}
        Dim IndiceArchivos As Int16 = 29
        Try

            result = 1000

            While Not result


                Dim CSV As New Class_CSV_Read
                If IndiceArchivos > Archivos.Count - 1 Then
                    IndiceArchivos = 0
                    Desede = 0
                    Asta = 119
                    msg("")
                End If
                msg("")
                msg("lee archivo =" & Archivos(IndiceArchivos))
                Dim Dateado As List(Of Class_ArchivoTrading.Archivo_Trading) = CSV.Read_list(Archivos(IndiceArchivos))
                Training.Clear()
                datosTest.Clear()
                Chart1_Reset({0})
                Chart1_Reset({1})
                msg("  registros =" & Dateado.Count)
                Dim indiceDateado As Integer = 0
                Dim EpocasAsta As Integer = 0

                If Asta < Dateado.Count - 1 Then
                    ' Dim resto As Double = Math.Ab(Dateado.Count, 120)
                    EpocasAsta = (Dateado.Count - 2) - Asta
                Else
                    EpocasAsta = Dateado.Count - 1
                End If

                For indiceEpocas As Integer = Desede To EpocasAsta
                    indiceDateado = indiceEpocas
                    Dim Entradas(119) As Double
                    For indice As Integer = 0 To 119 Step 6
                        Try


                            Dim valorOpen As Double = CDbl(Dateado.Item(indiceDateado).Open) / 200000

                            Try
                                If CDbl(Dateado.Item(indiceDateado).Open) < CDbl(Dateado.Item(indiceDateado - 1).Open) Then
                                    valorOpen = (CDbl(Dateado.Item(indiceDateado).Open) - (CDbl(Dateado.Item(indiceDateado - 1).Open) - CDbl(Dateado.Item(indiceDateado).Open))) / 200000
                                ElseIf CDbl(Dateado.Item(indiceDateado).Open) > CDbl(Dateado.Item(indiceDateado - 1).Open) Then
                                    valorOpen = (CDbl(Dateado.Item(indiceDateado).Open) + (CDbl(Dateado.Item(indiceDateado).Open) - CDbl(Dateado.Item(indiceDateado - 1).Open))) / 200000
                                End If
                            Catch ex As Exception

                            End Try
                            Entradas.SetValue(valorOpen, indice)
                            'If indiceDateado < PictureBox_ImagenRed.Width Then
                            '    GraficosBMP1.SetPixel(indiceDateado, valorOpen * 120, Color.Black)
                            'End If
                            Dim valorHigh As Double = CDbl(Dateado.Item(indiceDateado).High) / 200000
                            Entradas.SetValue(valorHigh, indice + 1)
                            Dim valorLow As Double = CDbl(Dateado.Item(indiceDateado).Low) / 200000
                            Entradas.SetValue(valorLow, indice + 2)
                            Dim valorClose As Double = CDbl(Dateado.Item(indiceDateado).Close) / 200000
                            Entradas.SetValue(valorClose, indice + 3)
                            Dim valorAdjClose As Double = CDbl(Dateado.Item(indiceDateado).AdjClose) / 200000
                            Entradas.SetValue(valorAdjClose, indice + 4)
                            Dim valorVolume As Double = CDbl(Dateado.Item(indiceDateado).Volume) / 250000000000
                            Entradas.SetValue(valorVolume, indice + 5)


                            'Chart1.Series("Series_Open").Points.AddXY(Dateado.Item(indiceDateado).Fecha, Dateado.Item(indiceDateado).Low, Dateado.Item(indiceDateado).High, Dateado.Item(indiceDateado).Close, Dateado.Item(indiceDateado).Open, Dateado.Item(indiceDateado).AdjClose, Dateado.Item(indiceDateado).Volume / 10000000)
                            'If Dateado.Item(indiceDateado).Close > Dateado.Item(indiceDateado).Open Then
                            '    Chart1.Series("Series_Open").Points(Chart1.Series("Series_Open").Points.Count - 1).Color = Color.Green
                            'ElseIf Dateado.Item(indiceDateado).Close < Dateado.Item(indiceDateado).Open Then
                            '    Chart1.Series("Series_Open").Points(Chart1.Series("Series_Open").Points.Count - 1).Color = Color.Red
                            'End If
                            'Chart1_ValueValores({0, Dateado.Item(indiceDateado).Fecha, Dateado.Item(indiceDateado).Low, Dateado.Item(indiceDateado).High, Dateado.Item(indiceDateado).Close, Dateado.Item(indiceDateado).Open, Dateado.Item(indiceDateado).AdjClose, Dateado.Item(indiceDateado).Volume / 10000000})
                            'Chart1_ValuePrediccion({0, Dateado.Item(indiceDateado).Fecha, 0, 0.1})
                            'Chart1.Series("Series_Prediccion").Points(Chart1.Series("Series_Prediccion").Points.Count - 1).Color = Color.White
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                        indiceDateado += 1
                        If indiceDateado > Dateado.Count - 1 Then
                            indiceDateado = 0
                            Asta = 119
                            Desede = 0
                            IndiceArchivos = +1

                            If indice = 119 Then
                                msg("ok file")
                                Desede = 0
                                Asta = 119
                                GoTo 1001
                            Else
                                msg("no end read, ok file")
                                GoTo 1111
                            End If

                        End If
                        If IndiceArchivos > Archivos.Count - 1 Then
                            IndiceArchivos = 0
                            Desede = 0
                            Asta = 119
                            msg("")
                            GoTo 1111
                        End If
                    Next

                    'Dim Salidas() As Decimal = {CDec(Dateado.Item(indiceDateado).Open)}
1001:               Try

                        Dim DatoSalida1 As Double
                        Dim DatoSalida2 As Double
                        Select Case Entrenamiento
                            Case "Open"

                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Open) / 200000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Open) / 200000
                                Try

                                    If CDbl(Dateado.Item(indiceDateado + 1).Open) < CDbl(Dateado.Item(indiceDateado).Open) Then
                                        DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Open) / 220000
                                    ElseIf CDbl(Dateado.Item(indiceDateado + 1).Open) > CDbl(Dateado.Item(indiceDateado).Open) Then
                                        DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Open) / 180000
                                    End If

                                    If CDbl(Dateado.Item(indiceDateado - 1).Open) < CDbl(Dateado.Item(indiceDateado).Open) Then
                                        DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Open) / 190000
                                    ElseIf CDbl(Dateado.Item(indiceDateado - 1).Open) > CDbl(Dateado.Item(indiceDateado).Open) Then
                                        DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Open) / 210000
                                    End If

                                Catch ex As Exception

                                End Try

                            Case "Max"
                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).High) / 200000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).High) / 200000
                            Case "Min"
                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Low) / 200000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Low) / 200000
                            Case "Close"
                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Close) / 200000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Close) / 200000
                            Case "Volume"
                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Volume) / 250000000000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Volume) / 250000000000
                            Case Else
                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Open) / 200000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Open) / 200000
                        End Select




                        Training.Add(New Training1(Entradas, {DatoSalida1, DatoSalida2}))
                        datosTest.Add(New Testing(Entradas))
                        Asta = Asta + 1
                        Desede = Desede + 1
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try


                Next

1111:

                IndiceArchivos += 1
                'Img(GraficosBMP1)

                Desede = 0
                Asta = 119

                Network.Train(Training, datos.epochs, Network.LearningRate)



                msg("error=" & Network.TotalError)
                Try
                    msg("error/rows=" & Network.TotalError / Dateado.Count)
                Catch ex As Exception

                End Try

                'Console.WriteLine(String.Format("Total error on correctly predicting training set: {0}", Network.TotalError))
                'Console.ReadLine()


                Try

                    Dim Resultados As New List(Of Double)
                    Resultados = Network.OutputLayer.ExtractOutputs()
                    'Resultados = Network.TestList(datosTest)
                    'For indice1 As Integer = 1 To PictureBox2.Size.Width - 1
                    Dim Valor As Double = (Resultados.Item(0) * 200000)
                    '    If Valor < 1 Then
                    '        GraficosBMP2.SetPixel(indiceDateado, 1, Color.Blue)
                    '    ElseIf Valor > 119 Then
                    '        GraficosBMP2.SetPixel(indiceDateado, 119, Color.Red)
                    '    Else
                    '        GraficosBMP2.SetPixel(indiceDateado, Valor, Color.Black)
                    '    End If

                    'Next

                    Chart1_ValuePrediccion({3, Dateado.Item(indiceDateado).Fecha, Valor, 0.1})
                    Chart1_ValuePrediccion({4, Dateado.Item(indiceDateado).Fecha, Resultados.Item(1) * 200000, 0.1})

                Catch ex As Exception

                End Try


                result -= 1
                Threading.Thread.Sleep(300)
            End While


            msg("end Thread")

        Catch ex As Exception

        End Try




    End Sub

    Private Sub Button_Entrenamiento2diasSaltosCSV_Click(sender As Object, e As EventArgs) Handles Button_Entrenamiento2diasSaltosCSV.Click
        Try

            Entrenamiento = ComboBox_Entrenamiento.Text

            Dim DatosEntrenamiento As New Class_ArchivoEntrenamiento
            DatosEntrenamiento.data = Training
            DatosEntrenamiento.epochs = TextBox_EpocasEntrenamiento.Text
            DatosEntrenamiento.min_error = Replace(TextBox_FactorActivacion.Text, ".", ",")
            ' Dim Training As New List(Of Training)
            Network.LearningRate = Replace(TextBox_AlfaEntrenamiento.Text, ".", ",")

            Network.Momentum = Replace(TextBox_Momento.Text.Trim, ".", ",")
            RichTextBox1.Text = ""
            ctThread = New Threading.Thread(AddressOf Entrenamiento2DiasSaltosCSV)
            AddHandler Event_Mensage, AddressOf msg
            ctThread.Start(DatosEntrenamiento)
            Threading.Thread.Sleep(300)


        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Private Sub Entrenamiento2DiasSaltosCSV(datos As Class_ArchivoEntrenamiento)

        Dim datosTest As New List(Of Testing)
        Dim bitMap As New Bitmap(PictureBox_ImagenRed.Width, PictureBox_ImagenRed.Height)
        Dim GraficosBMP1 As New Bitmap(bitMap)
        Dim GraficosBMP2 As New Bitmap(bitMap)

        Dim Desede As Integer = 0
        Dim Asta As Integer = 119
        'Dim Archivos() As String '= {"BTC-EUR_2019To2021_EUR.csv", "IBM_1986To2021.csv", "ETH-EUR_2019To2021_EUR.csv", "ETH-USD_2019To2021.csv", "EUR=X_2003To2021.csv", "LTC-EUR_2019To2021_EUR.csv", "PHM.MC_2016To2021_USD.csv", "KO_1962To2021.csv", "AMZN_1997To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "INTC_1980To2021.csv", "PYPL_2015To2021.csv"}
        Dim Archivos() As String = {"^IBEX_1993To2021.csv", "ETH-USD_2019To2021.csv", "TRX-USD_2017To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "BTC-USD_2014_2021.csv", "AMZN-USD_1997To2021.csv", "AAPL_1980To2021_USD.csv", "^IBEX_1993To2021.csv", "BTC-USD_2014_2021.csv", "LTC-USD_2014To2021.csv", "INTC-USD_1980To2021.csv", "AAPL_1980To2021_USD.csv", "BCH-USD_2017To2021.csv", "AMZN-USD_1997To2021.csv", "BTC-USD_2014_2021.csv", "BNB-USD_2017To2021.csv", "BTC-USD_2014_2021.csv", "ETH-USD_2019To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "BTC-USD_2014_2021.csv", "NVDA_1999To2021_USD.csv", "TRX-USD_2017To2021.csv", "LTC-USD_2014To2021.csv"}

        'Dim listaArchivos = FileIO.FileSystem.GetFiles(My.Application.Info.DirectoryPath & "\Datos\")
        'ReDim Archivos(listaArchivos.Count)
        'For indice As Integer = 0 To listaArchivos.Count - 1
        '    Dim Archivo As New System.IO.FileInfo(listaArchivos(indice))
        '    Archivos.SetValue(Archivo.Name, indice)
        'Next

        '{"BTC-EUR_2019To2021_EUR.csv", "IBM_1986To2021.csv", "ETH-EUR_2019To2021_EUR.csv", "ETH-USD_2019To2021.csv", "BTC-EUR_2019To2021_EUR.csv", "EUR=X_2003To2021.csv", "LTC-EUR_2019To2021_EUR.csv", "BTC-EUR_2019To2021_EUR.csv", "PHM.MC_2016To2021_USD.csv", "KO_1962To2021.csv", "AMZN_1997To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "INTC_1980To2021.csv", "PYPL_2015To2021.csv"}
        Dim IndiceArchivos As Int16 = 0
        Try

            result = 1000

            While Not result


                Dim CSV As New Class_CSV_Read
                If IndiceArchivos > Archivos.Count - 1 Then
                    IndiceArchivos = 0
                    Desede = 0
                    Asta = 119
                    msg("")
                End If
                msg("")
                msg("lee archivo =" & Archivos(IndiceArchivos))
                Dim Dateado As List(Of Class_ArchivoTrading.Archivo_Trading) = CSV.Read_list(Archivos(IndiceArchivos))
                Training.Clear()
                datosTest.Clear()
                Chart1_Reset({0})
                Chart1_Reset({1})
                msg("  registros =" & Dateado.Count)
                Dim indiceDateado As Integer = 0
                Dim EpocasAsta As Integer = 0

                If Asta < Dateado.Count - 1 Then
                    ' Dim resto As Double = Math.Ab(Dateado.Count, 120)
                    EpocasAsta = (Dateado.Count - 2) - Asta
                Else
                    EpocasAsta = Dateado.Count - 1
                End If

                For indiceEpocas As Integer = Desede To EpocasAsta
                    indiceDateado = indiceEpocas
                    Dim Entradas(119) As Double
                    For indice As Integer = 0 To 119 Step 6
                        Try


                            Dim valorOpen As Double = CDbl(Dateado.Item(indiceDateado).Open) / 200000

                            Try
                                If CDbl(Dateado.Item(indiceDateado).Open) < CDbl(Dateado.Item(indiceDateado - 1).Open) Then
                                    valorOpen = (CDbl(Dateado.Item(indiceDateado).Open) - (CDbl(Dateado.Item(indiceDateado - 1).Open) - CDbl(Dateado.Item(indiceDateado).Open))) / 200000
                                ElseIf CDbl(Dateado.Item(indiceDateado).Open) > CDbl(Dateado.Item(indiceDateado - 1).Open) Then
                                    valorOpen = (CDbl(Dateado.Item(indiceDateado).Open) + (CDbl(Dateado.Item(indiceDateado).Open) - CDbl(Dateado.Item(indiceDateado - 1).Open))) / 200000
                                End If
                            Catch ex As Exception

                            End Try
                            Entradas.SetValue(valorOpen, indice)
                            'If indiceDateado < PictureBox_ImagenRed.Width Then
                            '    GraficosBMP1.SetPixel(indiceDateado, valorOpen * 120, Color.Black)
                            'End If
                            Dim valorHigh As Double = CDbl(Dateado.Item(indiceDateado).High) / 200000
                            Entradas.SetValue(valorHigh, indice + 1)
                            Dim valorLow As Double = CDbl(Dateado.Item(indiceDateado).Low) / 200000
                            Entradas.SetValue(valorLow, indice + 2)
                            Dim valorClose As Double = CDbl(Dateado.Item(indiceDateado).Close) / 200000
                            Entradas.SetValue(valorClose, indice + 3)
                            Dim valorAdjClose As Double = CDbl(Dateado.Item(indiceDateado).AdjClose) / 200000
                            Entradas.SetValue(valorAdjClose, indice + 4)
                            Dim valorVolume As Double = CDbl(Dateado.Item(indiceDateado).Volume) / 250000000000
                            Entradas.SetValue(valorVolume, indice + 5)


                            'Chart1.Series("Series_Open").Points.AddXY(Dateado.Item(indiceDateado).Fecha, Dateado.Item(indiceDateado).Low, Dateado.Item(indiceDateado).High, Dateado.Item(indiceDateado).Close, Dateado.Item(indiceDateado).Open, Dateado.Item(indiceDateado).AdjClose, Dateado.Item(indiceDateado).Volume / 10000000)
                            'If Dateado.Item(indiceDateado).Close > Dateado.Item(indiceDateado).Open Then
                            '    Chart1.Series("Series_Open").Points(Chart1.Series("Series_Open").Points.Count - 1).Color = Color.Green
                            'ElseIf Dateado.Item(indiceDateado).Close < Dateado.Item(indiceDateado).Open Then
                            '    Chart1.Series("Series_Open").Points(Chart1.Series("Series_Open").Points.Count - 1).Color = Color.Red
                            'End If
                            Chart1_ValueValores({0, Dateado.Item(indiceDateado).Fecha, Dateado.Item(indiceDateado).Low, Dateado.Item(indiceDateado).High, Dateado.Item(indiceDateado).Close, Dateado.Item(indiceDateado).Open, Dateado.Item(indiceDateado).AdjClose, Dateado.Item(indiceDateado).Volume / 10000000})
                            Chart1_ValuePrediccion({0, Dateado.Item(indiceDateado).Fecha, 0, 0.1})
                            'Chart1.Series("Series_Prediccion").Points(Chart1.Series("Series_Prediccion").Points.Count - 1).Color = Color.White
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                        indiceDateado += 1
                        If indiceDateado > Dateado.Count - 1 Then
                            indiceDateado = 0
                            Asta = 119
                            Desede = 0
                            IndiceArchivos = +1

                            If indice = 119 Then
                                msg("ok file")
                                Desede = 0
                                Asta = 119
                                GoTo 1001
                            Else
                                msg("no end read, ok file")
                                GoTo 1111
                            End If

                        End If
                        If IndiceArchivos > Archivos.Count - 1 Then
                            IndiceArchivos = 0
                            Desede = 0
                            Asta = 119
                            msg("")
                            GoTo 1111
                        End If
                    Next

                    'Dim Salidas() As Decimal = {CDec(Dateado.Item(indiceDateado).Open)}
1001:               Try

                        Dim DatoSalida1 As Double
                        Dim DatoSalida2 As Double
                        Select Case Entrenamiento
                            Case "Open"

                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Open) / 200000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Open) / 200000
                                Try

                                    If CDbl(Dateado.Item(indiceDateado + 1).Open) < CDbl(Dateado.Item(indiceDateado).Open) Then
                                        DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Open) / 220000
                                    ElseIf CDbl(Dateado.Item(indiceDateado + 1).Open) > CDbl(Dateado.Item(indiceDateado).Open) Then
                                        DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Open) / 180000
                                    End If

                                    If CDbl(Dateado.Item(indiceDateado - 1).Open) < CDbl(Dateado.Item(indiceDateado).Open) Then
                                        DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Open) / 190000
                                    ElseIf CDbl(Dateado.Item(indiceDateado - 1).Open) > CDbl(Dateado.Item(indiceDateado).Open) Then
                                        DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Open) / 210000
                                    End If

                                Catch ex As Exception

                                End Try

                            Case "Max"
                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).High) / 200000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).High) / 200000
                            Case "Min"
                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Low) / 200000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Low) / 200000
                            Case "Close"
                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Close) / 200000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Close) / 200000
                            Case "Volume"
                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Volume) / 250000000000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Volume) / 250000000000
                            Case Else
                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Open) / 200000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Open) / 200000
                        End Select




                        Training.Add(New Training1(Entradas, {DatoSalida1, DatoSalida2}))
                        datosTest.Add(New Testing(Entradas))
                        Asta = Asta + 1
                        Desede = Desede + 1
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try


                Next

1111:

                IndiceArchivos += 1
                'Img(GraficosBMP1)

                Desede = 0
                Asta = 119

                Network.Train(Training, datos.epochs, Network.LearningRate)



                msg("error=" & Network.TotalError)
                Try
                    msg("error/rows=" & Network.TotalError / Dateado.Count)
                Catch ex As Exception

                End Try

                'Console.WriteLine(String.Format("Total error on correctly predicting training set: {0}", Network.TotalError))
                'Console.ReadLine()


                Try

                    Dim Resultados As New List(Of Double)
                    Resultados = Network.OutputLayer.ExtractOutputs()
                    'Resultados = Network.TestList(datosTest)
                    'For indice1 As Integer = 1 To PictureBox2.Size.Width - 1
                    Dim Valor As Double = (Resultados.Item(0) * 200000)
                    '    If Valor < 1 Then
                    '        GraficosBMP2.SetPixel(indiceDateado, 1, Color.Blue)
                    '    ElseIf Valor > 119 Then
                    '        GraficosBMP2.SetPixel(indiceDateado, 119, Color.Red)
                    '    Else
                    '        GraficosBMP2.SetPixel(indiceDateado, Valor, Color.Black)
                    '    End If

                    'Next

                    Chart1_ValuePrediccion({3, Dateado.Item(indiceDateado).Fecha, Valor, 0.1})
                    Chart1_ValuePrediccion({4, Dateado.Item(indiceDateado).Fecha, Resultados.Item(1) * 200000, 0.1})

                Catch ex As Exception

                End Try


                result -= 1
                Threading.Thread.Sleep(300)
            End While


            msg("end Thread")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_Entrenamiento2diasClasicoCSV_Click(sender As Object, e As EventArgs) ' Handles Button_Entrenamiento2diasClasicoCSV.Click
        Try

            Entrenamiento = ComboBox_Entrenamiento.Text

            Dim DatosEntrenamiento As New Class_ArchivoEntrenamiento
            DatosEntrenamiento.data = Training
            DatosEntrenamiento.epochs = TextBox_EpocasEntrenamiento.Text
            DatosEntrenamiento.min_error = Replace(TextBox_FactorActivacion.Text, ".", ",")

            ' Dim Training As New List(Of Training)
            Network.LearningRate = Replace(TextBox_AlfaEntrenamiento.Text, ".", ",")
            Network.MinError = Replace(TextBox_FactorActivacion.Text, ".", ",")
            Network.Momentum = Replace(TextBox_Momento.Text.Trim, ".", ",")
            RichTextBox1.Text = ""
            ctThread = New Threading.Thread(AddressOf Entrenamiento2DiasClasicoCSV)
            AddHandler Event_Mensage, AddressOf msg
            ctThread.Start(DatosEntrenamiento)
            Threading.Thread.Sleep(300)


        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Private Sub Entrenamiento2DiasClasicoCSV(datos As Class_ArchivoEntrenamiento)

        Dim datosTest As New List(Of Testing)
        Dim bitMap As New Bitmap(PictureBox_ImagenRed.Width, PictureBox_ImagenRed.Height)
        Dim GraficosBMP1 As New Bitmap(bitMap)
        Dim GraficosBMP2 As New Bitmap(bitMap)

        Dim Desede As Integer = 0
        Dim Asta As Integer = 119
        'Dim Archivos() As String '= {"BTC-EUR_2019To2021_EUR.csv", "IBM_1986To2021.csv", "ETH-EUR_2019To2021_EUR.csv", "ETH-USD_2019To2021.csv", "EUR=X_2003To2021.csv", "LTC-EUR_2019To2021_EUR.csv", "PHM.MC_2016To2021_USD.csv", "KO_1962To2021.csv", "AMZN_1997To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "INTC_1980To2021.csv", "PYPL_2015To2021.csv"}
        Dim Archivos() As String = {"^IBEX_1993To2021.csv", "ETH-USD_2019To2021.csv", "TRX-USD_2017To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "BTC-USD_2014_2021.csv", "AMZN-USD_1997To2021.csv", "AAPL_1980To2021_USD.csv", "^IBEX_1993To2021.csv", "BTC-USD_2014_2021.csv", "LTC-USD_2014To2021.csv", "INTC-USD_1980To2021.csv", "AAPL_1980To2021_USD.csv", "BCH-USD_2017To2021.csv", "AMZN-USD_1997To2021.csv", "BTC-USD_2014_2021.csv", "BNB-USD_2017To2021.csv", "BTC-USD_2014_2021.csv", "ETH-USD_2019To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "BTC-USD_2014_2021.csv", "NVDA_1999To2021_USD.csv", "TRX-USD_2017To2021.csv", "LTC-USD_2014To2021.csv"}

        Dim listaArchivos = FileIO.FileSystem.GetFiles(My.Application.Info.DirectoryPath & "\Datos\")
        ReDim Archivos(listaArchivos.Count)
        For indice As Integer = 0 To listaArchivos.Count - 1
            Dim Archivo As New System.IO.FileInfo(listaArchivos(indice))
            Archivos.SetValue(Archivo.Name, indice)
        Next

        '{"BTC-EUR_2019To2021_EUR.csv", "IBM_1986To2021.csv", "ETH-EUR_2019To2021_EUR.csv", "ETH-USD_2019To2021.csv", "BTC-EUR_2019To2021_EUR.csv", "EUR=X_2003To2021.csv", "LTC-EUR_2019To2021_EUR.csv", "BTC-EUR_2019To2021_EUR.csv", "PHM.MC_2016To2021_USD.csv", "KO_1962To2021.csv", "AMZN_1997To2021.csv", "MELI_USD_mercadolibre_2007To2021.csv", "INTC_1980To2021.csv", "PYPL_2015To2021.csv"}
        Dim IndiceArchivos As Int16 = 23 ' 4, 27 , tx26, x24, 21, x16, x10, x7, x3, x5, x9
        Try

            result = 1000

            While Not result


                Dim CSV As New Class_CSV_Read
                If IndiceArchivos > Archivos.Count - 1 Then
                    IndiceArchivos = 0
                    Desede = 0
                    Asta = 119
                    msg("")
                End If
                msg("")
                msg("lee archivo =" & Archivos(IndiceArchivos) & "  " & IndiceArchivos)
                Dim Dateado As List(Of Class_ArchivoTrading.Archivo_Trading) = CSV.Read_list(Archivos(IndiceArchivos))
                Training.Clear()
                datosTest.Clear()
                Chart1_Reset({0})
                Chart1_Reset({1})
                msg("  registros =" & Dateado.Count)
                Dim indiceDateado As Integer = 0
                Dim EpocasAsta As Integer = 0

                If Asta < Dateado.Count - 1 Then
                    ' Dim resto As Double = Math.Ab(Dateado.Count, 120)
                    EpocasAsta = (Dateado.Count - 2) - Asta
                Else
                    EpocasAsta = Dateado.Count - 1
                End If

                For indiceEpocas As Integer = Desede To EpocasAsta
                    indiceDateado = indiceEpocas
                    Dim Entradas(119) As Double
                    For indice As Integer = 0 To 119 Step 6
                        Try


                            Dim valorOpen As Double = CDbl(Dateado.Item(indiceDateado).Open) / 200000

                            Try
                                If CDbl(Dateado.Item(indiceDateado).Open) < CDbl(Dateado.Item(indiceDateado - 1).Open) Then
                                    valorOpen = (CDbl(Dateado.Item(indiceDateado).Open) - (CDbl(Dateado.Item(indiceDateado - 1).Open) - CDbl(Dateado.Item(indiceDateado).Open))) / 200000
                                ElseIf CDbl(Dateado.Item(indiceDateado).Open) > CDbl(Dateado.Item(indiceDateado - 1).Open) Then
                                    valorOpen = (CDbl(Dateado.Item(indiceDateado).Open) + (CDbl(Dateado.Item(indiceDateado).Open) - CDbl(Dateado.Item(indiceDateado - 1).Open))) / 200000
                                End If
                            Catch ex As Exception

                            End Try
                            Entradas.SetValue(valorOpen, indice)
                            'If indiceDateado < PictureBox_ImagenRed.Width Then
                            '    GraficosBMP1.SetPixel(indiceDateado, valorOpen * 120, Color.Black)
                            'End If
                            Dim valorHigh As Double = CDbl(Dateado.Item(indiceDateado).High) / 200000
                            Entradas.SetValue(valorHigh, indice + 1)
                            Dim valorLow As Double = CDbl(Dateado.Item(indiceDateado).Low) / 200000
                            Entradas.SetValue(valorLow, indice + 2)
                            Dim valorClose As Double = CDbl(Dateado.Item(indiceDateado).Close) / 200000
                            Entradas.SetValue(valorClose, indice + 3)
                            Dim valorAdjClose As Double = CDbl(Dateado.Item(indiceDateado).AdjClose) / 200000
                            Entradas.SetValue(valorAdjClose, indice + 4)
                            Dim valorVolume As Double = CDbl(Dateado.Item(indiceDateado).Volume) / 250000000000
                            Entradas.SetValue(valorVolume, indice + 5)


                            'Chart1.Series("Series_Open").Points.AddXY(Dateado.Item(indiceDateado).Fecha, Dateado.Item(indiceDateado).Low, Dateado.Item(indiceDateado).High, Dateado.Item(indiceDateado).Close, Dateado.Item(indiceDateado).Open, Dateado.Item(indiceDateado).AdjClose, Dateado.Item(indiceDateado).Volume / 10000000)
                            'If Dateado.Item(indiceDateado).Close > Dateado.Item(indiceDateado).Open Then
                            '    Chart1.Series("Series_Open").Points(Chart1.Series("Series_Open").Points.Count - 1).Color = Color.Green
                            'ElseIf Dateado.Item(indiceDateado).Close < Dateado.Item(indiceDateado).Open Then
                            '    Chart1.Series("Series_Open").Points(Chart1.Series("Series_Open").Points.Count - 1).Color = Color.Red
                            'End If
                            'Chart1_ValueValores({0, Dateado.Item(indiceDateado).Fecha, Dateado.Item(indiceDateado).Low, Dateado.Item(indiceDateado).High, Dateado.Item(indiceDateado).Close, Dateado.Item(indiceDateado).Open, Dateado.Item(indiceDateado).AdjClose, Dateado.Item(indiceDateado).Volume / 10000000})
                            'Chart1_ValuePrediccion({0, Dateado.Item(indiceDateado).Fecha, 0, 0.1})
                            'Chart1.Series("Series_Prediccion").Points(Chart1.Series("Series_Prediccion").Points.Count - 1).Color = Color.White
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                        indiceDateado += 1
                        If indiceDateado > Dateado.Count - 1 Then
                            indiceDateado = 0
                            Asta = 119
                            Desede = 0
                            IndiceArchivos = +1

                            If indice = 119 Then
                                msg("ok file")
                                Desede = 0
                                Asta = 119
                                GoTo 1001
                            Else
                                msg("no end read, ok file")
                                GoTo 1111
                            End If

                        End If
                        If IndiceArchivos > Archivos.Count - 1 Then
                            IndiceArchivos = 0
                            Desede = 0
                            Asta = 119
                            msg("")
                            GoTo 1111
                        End If
                    Next

                    'Dim Salidas() As Decimal = {CDec(Dateado.Item(indiceDateado).Open)}
1001:               Try

                        Dim DatoSalida1 As Double
                        Dim DatoSalida2 As Double
                        Select Case Entrenamiento
                            Case "Open"

                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Open) / 200000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Open) / 200000
                                Try

                                    If CDbl(Dateado.Item(indiceDateado + 1).Open) < CDbl(Dateado.Item(indiceDateado).Open) Then
                                        DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Open) / 220000
                                    ElseIf CDbl(Dateado.Item(indiceDateado + 1).Open) > CDbl(Dateado.Item(indiceDateado).Open) Then
                                        DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Open) / 180000
                                    End If

                                    If CDbl(Dateado.Item(indiceDateado - 1).Open) < CDbl(Dateado.Item(indiceDateado).Open) Then
                                        DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Open) / 190000
                                    ElseIf CDbl(Dateado.Item(indiceDateado - 1).Open) > CDbl(Dateado.Item(indiceDateado).Open) Then
                                        DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Open) / 210000
                                    End If

                                Catch ex As Exception

                                End Try

                            Case "Max"
                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).High) / 200000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).High) / 200000
                            Case "Min"
                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Low) / 200000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Low) / 200000
                            Case "Close"
                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Close) / 200000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Close) / 200000
                            Case "Volume"
                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Volume) / 250000000000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Volume) / 250000000000
                            Case Else
                                DatoSalida1 = CDbl(Dateado.Item(indiceDateado).Open) / 200000
                                DatoSalida2 = CDbl(Dateado.Item(indiceDateado + 1).Open) / 200000
                        End Select




                        Training.Add(New Training1(Entradas, {DatoSalida1, DatoSalida2}))
                        datosTest.Add(New Testing(Entradas))
                        Asta = Asta + 1
                        Desede = Desede + 1
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try


                Next

1111:

                IndiceArchivos += 1
                'Img(GraficosBMP1)

                Desede = 0
                Asta = 119

                Network.TrainClasic(Training, datos.epochs, Network.MinError)



                msg("error=" & Network.TotalError)
                Try
                    msg("error/rows=" & Network.TotalError / Dateado.Count)
                Catch ex As Exception

                End Try

                'Console.WriteLine(String.Format("Total error on correctly predicting training set: {0}", Network.TotalError))
                'Console.ReadLine()


                Try

                    Dim Resultados As New List(Of Double)
                    Resultados = Network.OutputLayer.ExtractOutputs()
                    'Resultados = Network.TestList(datosTest)
                    'For indice1 As Integer = 1 To PictureBox2.Size.Width - 1
                    Dim Valor As Double = (Resultados.Item(0) * 200000)
                    '    If Valor < 1 Then
                    '        GraficosBMP2.SetPixel(indiceDateado, 1, Color.Blue)
                    '    ElseIf Valor > 119 Then
                    '        GraficosBMP2.SetPixel(indiceDateado, 119, Color.Red)
                    '    Else
                    '        GraficosBMP2.SetPixel(indiceDateado, Valor, Color.Black)
                    '    End If

                    'Next

                    Chart1_ValuePrediccion({3, Dateado.Item(indiceDateado).Fecha, Valor, 0.1})
                    Chart1_ValuePrediccion({4, Dateado.Item(indiceDateado).Fecha, Resultados.Item(1) * 200000, 0.1})

                Catch ex As Exception

                End Try


                result -= 1
                Threading.Thread.Sleep(300)
            End While


            msg("end Thread")

        Catch ex As Exception

        End Try
    End Sub





#End Region

    Private Sub Button_Circulo_Click(sender As Object, e As EventArgs) Handles Button_Circulo.Click

    End Sub

    Private Sub Button_Aentrenamiento_Click(sender As Object, e As EventArgs) Handles Button_Aentrenamiento.Click

    End Sub

    Private Sub Button_APrueba_Click(sender As Object, e As EventArgs) Handles Button_APrueba.Click

    End Sub

    Private Sub Button_BorrarEntrenamiento_Click(sender As Object, e As EventArgs) Handles Button_BorrarEntrenamiento.Click

    End Sub

    Private Sub Button_CargarImagen_Click(sender As Object, e As EventArgs) Handles Button_CargarImagen.Click

    End Sub

    Private Sub Button_GenerarDataSet_Click(sender As Object, e As EventArgs) Handles Button_GenerarDataSet.Click

    End Sub

    Private Sub Button_GenerarEntrenaCirculo_Click(sender As Object, e As EventArgs) Handles Button_GenerarEntrenaCirculo.Click

    End Sub

    Private Sub Button_DataSheEntrenamiento_Click(sender As Object, e As EventArgs) Handles Button_DataSheEntrenamiento.Click

    End Sub

    Private Sub Button_GenerarEntrenaCirculo2_Click(sender As Object, e As EventArgs) Handles Button_GenerarEntrenaCirculo2.Click

    End Sub

End Class



