<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button_Test = New System.Windows.Forms.Button()
        Me.Button_DetenerNeurona = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button_EntrenamientoSencillo = New System.Windows.Forms.Button()
        Me.Button_Entrenamiento = New System.Windows.Forms.Button()
        Me.Label_LearningRate = New System.Windows.Forms.Label()
        Me.Button_QuitarCapa = New System.Windows.Forms.Button()
        Me.ListBox_Neuronas = New System.Windows.Forms.ListBox()
        Me.Button_AñadirCapa = New System.Windows.Forms.Button()
        Me.PictureBox_ImagenRed = New System.Windows.Forms.PictureBox()
        Me.ComboBox_CerebrosLista = New System.Windows.Forms.ComboBox()
        Me.TextBox_Bias = New System.Windows.Forms.TextBox()
        Me.Button_Cargar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_GuardarNombre = New System.Windows.Forms.TextBox()
        Me.Button_Guardar = New System.Windows.Forms.Button()
        Me.TextBox_Capas = New System.Windows.Forms.TextBox()
        Me.TextBox_Momento = New System.Windows.Forms.TextBox()
        Me.Label_Momento = New System.Windows.Forms.Label()
        Me.TextBox_AlfaEntrenamiento = New System.Windows.Forms.TextBox()
        Me.Label_Independiente = New System.Windows.Forms.Label()
        Me.TextBox_Salidas = New System.Windows.Forms.TextBox()
        Me.TextBox_Independiente = New System.Windows.Forms.TextBox()
        Me.TextBox_Neuronas = New System.Windows.Forms.TextBox()
        Me.Label_Umbral = New System.Windows.Forms.Label()
        Me.TextBox_EpocasEntrenamiento = New System.Windows.Forms.TextBox()
        Me.TextBox_Umbral = New System.Windows.Forms.TextBox()
        Me.Label_EpocasEntrenamiento = New System.Windows.Forms.Label()
        Me.TextBox_FactorActivacion = New System.Windows.Forms.TextBox()
        Me.Label_FactorActivacion = New System.Windows.Forms.Label()
        Me.Label_Incremento = New System.Windows.Forms.Label()
        Me.TextBox_ConexionesNumero = New System.Windows.Forms.TextBox()
        Me.TextBox_Incremento = New System.Windows.Forms.TextBox()
        Me.Button_GenerarRed = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button_Circulo = New System.Windows.Forms.Button()
        Me.Label_X1 = New System.Windows.Forms.Label()
        Me.Label_Resultado = New System.Windows.Forms.Label()
        Me.Button_BorrarEntrenamiento = New System.Windows.Forms.Button()
        Me.TextBox_Target = New System.Windows.Forms.TextBox()
        Me.TextBox_X2 = New System.Windows.Forms.TextBox()
        Me.Button_Aentrenamiento = New System.Windows.Forms.Button()
        Me.Label_X2 = New System.Windows.Forms.Label()
        Me.TextBox_X1 = New System.Windows.Forms.TextBox()
        Me.Button_APrueba = New System.Windows.Forms.Button()
        Me.TextBox_Resultado = New System.Windows.Forms.TextBox()
        Me.Label_Target = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button_CargarImagen = New System.Windows.Forms.Button()
        Me.Button_GenerarEntrenaCirculo2 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button_GenerarEntrenaCirculo = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Button_GenerarDataSet = New System.Windows.Forms.Button()
        Me.Button_DataSheEntrenamiento = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label_TestArchivoIndice = New System.Windows.Forms.Label()
        Me.TextBox_TestArchivoIndice = New System.Windows.Forms.TextBox()
        Me.Button_EntrenamientoCsvVolumen = New System.Windows.Forms.Button()
        Me.Button_CargarDatosCSV = New System.Windows.Forms.Button()
        Me.Button_TestCSV = New System.Windows.Forms.Button()
        Me.Button_EntrenamientoCSV = New System.Windows.Forms.Button()
        Me.TextBox_LoadCSV_Asta = New System.Windows.Forms.TextBox()
        Me.TextBox_LoadCSV_Desde = New System.Windows.Forms.TextBox()
        Me.Label_LoadCSV = New System.Windows.Forms.Label()
        Me.TrackBar_TestCSV = New System.Windows.Forms.TrackBar()
        Me.ComboBox_Entrenamiento = New System.Windows.Forms.ComboBox()
        Me.Label_ZoomEntradas = New System.Windows.Forms.Label()
        Me.TextBox_ZoomEntradas = New System.Windows.Forms.TextBox()
        Me.Button_Entrenamiento2diasSaltosCSV = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox_ImagenRed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar_TestCSV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(722, 586)
        Me.TabControl1.TabIndex = 151
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button_Test)
        Me.TabPage1.Controls.Add(Me.Button_DetenerNeurona)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Button_EntrenamientoSencillo)
        Me.TabPage1.Controls.Add(Me.Button_Entrenamiento)
        Me.TabPage1.Controls.Add(Me.Label_LearningRate)
        Me.TabPage1.Controls.Add(Me.Button_QuitarCapa)
        Me.TabPage1.Controls.Add(Me.ListBox_Neuronas)
        Me.TabPage1.Controls.Add(Me.Button_AñadirCapa)
        Me.TabPage1.Controls.Add(Me.PictureBox_ImagenRed)
        Me.TabPage1.Controls.Add(Me.ComboBox_CerebrosLista)
        Me.TabPage1.Controls.Add(Me.TextBox_Bias)
        Me.TabPage1.Controls.Add(Me.Button_Cargar)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.TextBox_GuardarNombre)
        Me.TabPage1.Controls.Add(Me.Button_Guardar)
        Me.TabPage1.Controls.Add(Me.TextBox_Capas)
        Me.TabPage1.Controls.Add(Me.TextBox_Momento)
        Me.TabPage1.Controls.Add(Me.Label_Momento)
        Me.TabPage1.Controls.Add(Me.TextBox_AlfaEntrenamiento)
        Me.TabPage1.Controls.Add(Me.Label_Independiente)
        Me.TabPage1.Controls.Add(Me.TextBox_Salidas)
        Me.TabPage1.Controls.Add(Me.TextBox_Independiente)
        Me.TabPage1.Controls.Add(Me.TextBox_Neuronas)
        Me.TabPage1.Controls.Add(Me.Label_Umbral)
        Me.TabPage1.Controls.Add(Me.TextBox_EpocasEntrenamiento)
        Me.TabPage1.Controls.Add(Me.TextBox_Umbral)
        Me.TabPage1.Controls.Add(Me.Label_EpocasEntrenamiento)
        Me.TabPage1.Controls.Add(Me.TextBox_FactorActivacion)
        Me.TabPage1.Controls.Add(Me.Label_FactorActivacion)
        Me.TabPage1.Controls.Add(Me.Label_Incremento)
        Me.TabPage1.Controls.Add(Me.TextBox_ConexionesNumero)
        Me.TabPage1.Controls.Add(Me.TextBox_Incremento)
        Me.TabPage1.Controls.Add(Me.Button_GenerarRed)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(714, 560)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button_Test
        '
        Me.Button_Test.Location = New System.Drawing.Point(7, 503)
        Me.Button_Test.Name = "Button_Test"
        Me.Button_Test.Size = New System.Drawing.Size(101, 23)
        Me.Button_Test.TabIndex = 123
        Me.Button_Test.Text = "Test"
        Me.Button_Test.UseVisualStyleBackColor = True
        '
        'Button_DetenerNeurona
        '
        Me.Button_DetenerNeurona.Location = New System.Drawing.Point(7, 532)
        Me.Button_DetenerNeurona.Name = "Button_DetenerNeurona"
        Me.Button_DetenerNeurona.Size = New System.Drawing.Size(99, 23)
        Me.Button_DetenerNeurona.TabIndex = 122
        Me.Button_DetenerNeurona.Text = "Detener"
        Me.Button_DetenerNeurona.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(295, 476)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 23)
        Me.Button1.TabIndex = 121
        Me.Button1.Text = "Entrenamiento Progresivo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button_EntrenamientoSencillo
        '
        Me.Button_EntrenamientoSencillo.Location = New System.Drawing.Point(7, 476)
        Me.Button_EntrenamientoSencillo.Name = "Button_EntrenamientoSencillo"
        Me.Button_EntrenamientoSencillo.Size = New System.Drawing.Size(137, 23)
        Me.Button_EntrenamientoSencillo.TabIndex = 120
        Me.Button_EntrenamientoSencillo.Text = "Entrenamiento sencillo"
        Me.Button_EntrenamientoSencillo.UseVisualStyleBackColor = True
        '
        'Button_Entrenamiento
        '
        Me.Button_Entrenamiento.Location = New System.Drawing.Point(152, 476)
        Me.Button_Entrenamiento.Name = "Button_Entrenamiento"
        Me.Button_Entrenamiento.Size = New System.Drawing.Size(137, 23)
        Me.Button_Entrenamiento.TabIndex = 119
        Me.Button_Entrenamiento.Text = "Entrenamiento"
        Me.Button_Entrenamiento.UseVisualStyleBackColor = True
        '
        'Label_LearningRate
        '
        Me.Label_LearningRate.AutoSize = True
        Me.Label_LearningRate.Location = New System.Drawing.Point(23, 417)
        Me.Label_LearningRate.Name = "Label_LearningRate"
        Me.Label_LearningRate.Size = New System.Drawing.Size(166, 13)
        Me.Label_LearningRate.TabIndex = 118
        Me.Label_LearningRate.Text = "Learning rate (Alfa entrenamiento)"
        '
        'Button_QuitarCapa
        '
        Me.Button_QuitarCapa.Location = New System.Drawing.Point(346, 309)
        Me.Button_QuitarCapa.Name = "Button_QuitarCapa"
        Me.Button_QuitarCapa.Size = New System.Drawing.Size(42, 20)
        Me.Button_QuitarCapa.TabIndex = 117
        Me.Button_QuitarCapa.Text = "-"
        Me.Button_QuitarCapa.UseVisualStyleBackColor = True
        '
        'ListBox_Neuronas
        '
        Me.ListBox_Neuronas.FormattingEnabled = True
        Me.ListBox_Neuronas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ListBox_Neuronas.Items.AddRange(New Object() {"120"})
        Me.ListBox_Neuronas.Location = New System.Drawing.Point(240, 283)
        Me.ListBox_Neuronas.Name = "ListBox_Neuronas"
        Me.ListBox_Neuronas.Size = New System.Drawing.Size(100, 56)
        Me.ListBox_Neuronas.TabIndex = 116
        '
        'Button_AñadirCapa
        '
        Me.Button_AñadirCapa.Location = New System.Drawing.Point(346, 283)
        Me.Button_AñadirCapa.Name = "Button_AñadirCapa"
        Me.Button_AñadirCapa.Size = New System.Drawing.Size(42, 20)
        Me.Button_AñadirCapa.TabIndex = 115
        Me.Button_AñadirCapa.Text = "+"
        Me.Button_AñadirCapa.UseVisualStyleBackColor = True
        '
        'PictureBox_ImagenRed
        '
        Me.PictureBox_ImagenRed.Location = New System.Drawing.Point(7, 4)
        Me.PictureBox_ImagenRed.Name = "PictureBox_ImagenRed"
        Me.PictureBox_ImagenRed.Size = New System.Drawing.Size(701, 218)
        Me.PictureBox_ImagenRed.TabIndex = 108
        Me.PictureBox_ImagenRed.TabStop = False
        '
        'ComboBox_CerebrosLista
        '
        Me.ComboBox_CerebrosLista.FormattingEnabled = True
        Me.ComboBox_CerebrosLista.Location = New System.Drawing.Point(435, 505)
        Me.ComboBox_CerebrosLista.Name = "ComboBox_CerebrosLista"
        Me.ComboBox_CerebrosLista.Size = New System.Drawing.Size(273, 21)
        Me.ComboBox_CerebrosLista.TabIndex = 102
        '
        'TextBox_Bias
        '
        Me.TextBox_Bias.Location = New System.Drawing.Point(89, 280)
        Me.TextBox_Bias.Name = "TextBox_Bias"
        Me.TextBox_Bias.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Bias.TabIndex = 69
        Me.TextBox_Bias.Text = "1"
        '
        'Button_Cargar
        '
        Me.Button_Cargar.Location = New System.Drawing.Point(435, 532)
        Me.Button_Cargar.Name = "Button_Cargar"
        Me.Button_Cargar.Size = New System.Drawing.Size(273, 23)
        Me.Button_Cargar.TabIndex = 101
        Me.Button_Cargar.Text = "Cargar"
        Me.Button_Cargar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 283)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Bias"
        '
        'TextBox_GuardarNombre
        '
        Me.TextBox_GuardarNombre.Location = New System.Drawing.Point(136, 505)
        Me.TextBox_GuardarNombre.Name = "TextBox_GuardarNombre"
        Me.TextBox_GuardarNombre.Size = New System.Drawing.Size(277, 20)
        Me.TextBox_GuardarNombre.TabIndex = 98
        '
        'Button_Guardar
        '
        Me.Button_Guardar.Location = New System.Drawing.Point(136, 531)
        Me.Button_Guardar.Name = "Button_Guardar"
        Me.Button_Guardar.Size = New System.Drawing.Size(277, 23)
        Me.Button_Guardar.TabIndex = 97
        Me.Button_Guardar.Text = "Guardar"
        Me.Button_Guardar.UseVisualStyleBackColor = True
        '
        'TextBox_Capas
        '
        Me.TextBox_Capas.Location = New System.Drawing.Point(240, 362)
        Me.TextBox_Capas.Name = "TextBox_Capas"
        Me.TextBox_Capas.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Capas.TabIndex = 96
        Me.TextBox_Capas.Text = "1"
        '
        'TextBox_Momento
        '
        Me.TextBox_Momento.Location = New System.Drawing.Point(89, 332)
        Me.TextBox_Momento.Name = "TextBox_Momento"
        Me.TextBox_Momento.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Momento.TabIndex = 95
        Me.TextBox_Momento.Text = "0,3"
        '
        'Label_Momento
        '
        Me.Label_Momento.AutoSize = True
        Me.Label_Momento.Location = New System.Drawing.Point(34, 335)
        Me.Label_Momento.Name = "Label_Momento"
        Me.Label_Momento.Size = New System.Drawing.Size(51, 13)
        Me.Label_Momento.TabIndex = 94
        Me.Label_Momento.Text = "Momento"
        '
        'TextBox_AlfaEntrenamiento
        '
        Me.TextBox_AlfaEntrenamiento.Location = New System.Drawing.Point(195, 413)
        Me.TextBox_AlfaEntrenamiento.Name = "TextBox_AlfaEntrenamiento"
        Me.TextBox_AlfaEntrenamiento.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_AlfaEntrenamiento.TabIndex = 93
        Me.TextBox_AlfaEntrenamiento.Text = "0,0000001"
        '
        'Label_Independiente
        '
        Me.Label_Independiente.AutoSize = True
        Me.Label_Independiente.Enabled = False
        Me.Label_Independiente.Location = New System.Drawing.Point(8, 309)
        Me.Label_Independiente.Name = "Label_Independiente"
        Me.Label_Independiente.Size = New System.Drawing.Size(75, 13)
        Me.Label_Independiente.TabIndex = 76
        Me.Label_Independiente.Text = "Independiente"
        '
        'TextBox_Salidas
        '
        Me.TextBox_Salidas.Location = New System.Drawing.Point(346, 388)
        Me.TextBox_Salidas.Name = "TextBox_Salidas"
        Me.TextBox_Salidas.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Salidas.TabIndex = 92
        Me.TextBox_Salidas.Text = "1"
        '
        'TextBox_Independiente
        '
        Me.TextBox_Independiente.Enabled = False
        Me.TextBox_Independiente.Location = New System.Drawing.Point(89, 306)
        Me.TextBox_Independiente.Name = "TextBox_Independiente"
        Me.TextBox_Independiente.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Independiente.TabIndex = 77
        '
        'TextBox_Neuronas
        '
        Me.TextBox_Neuronas.Location = New System.Drawing.Point(240, 388)
        Me.TextBox_Neuronas.Name = "TextBox_Neuronas"
        Me.TextBox_Neuronas.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Neuronas.TabIndex = 91
        Me.TextBox_Neuronas.Text = "60"
        '
        'Label_Umbral
        '
        Me.Label_Umbral.AutoSize = True
        Me.Label_Umbral.Enabled = False
        Me.Label_Umbral.Location = New System.Drawing.Point(43, 231)
        Me.Label_Umbral.Name = "Label_Umbral"
        Me.Label_Umbral.Size = New System.Drawing.Size(40, 13)
        Me.Label_Umbral.TabIndex = 78
        Me.Label_Umbral.Text = "Umbral"
        '
        'TextBox_EpocasEntrenamiento
        '
        Me.TextBox_EpocasEntrenamiento.Location = New System.Drawing.Point(407, 440)
        Me.TextBox_EpocasEntrenamiento.Name = "TextBox_EpocasEntrenamiento"
        Me.TextBox_EpocasEntrenamiento.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_EpocasEntrenamiento.TabIndex = 90
        Me.TextBox_EpocasEntrenamiento.Text = "1"
        '
        'TextBox_Umbral
        '
        Me.TextBox_Umbral.Enabled = False
        Me.TextBox_Umbral.Location = New System.Drawing.Point(89, 228)
        Me.TextBox_Umbral.Name = "TextBox_Umbral"
        Me.TextBox_Umbral.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Umbral.TabIndex = 79
        '
        'Label_EpocasEntrenamiento
        '
        Me.Label_EpocasEntrenamiento.AutoSize = True
        Me.Label_EpocasEntrenamiento.Location = New System.Drawing.Point(273, 443)
        Me.Label_EpocasEntrenamiento.Name = "Label_EpocasEntrenamiento"
        Me.Label_EpocasEntrenamiento.Size = New System.Drawing.Size(128, 13)
        Me.Label_EpocasEntrenamiento.TabIndex = 89
        Me.Label_EpocasEntrenamiento.Text = "Epocas de entrenamiento"
        '
        'TextBox_FactorActivacion
        '
        Me.TextBox_FactorActivacion.Location = New System.Drawing.Point(407, 414)
        Me.TextBox_FactorActivacion.Name = "TextBox_FactorActivacion"
        Me.TextBox_FactorActivacion.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_FactorActivacion.TabIndex = 88
        Me.TextBox_FactorActivacion.Text = "0,1"
        '
        'Label_FactorActivacion
        '
        Me.Label_FactorActivacion.AutoSize = True
        Me.Label_FactorActivacion.Location = New System.Drawing.Point(312, 417)
        Me.Label_FactorActivacion.Name = "Label_FactorActivacion"
        Me.Label_FactorActivacion.Size = New System.Drawing.Size(89, 13)
        Me.Label_FactorActivacion.TabIndex = 87
        Me.Label_FactorActivacion.Text = "Facrot activacion"
        '
        'Label_Incremento
        '
        Me.Label_Incremento.AutoSize = True
        Me.Label_Incremento.Enabled = False
        Me.Label_Incremento.Location = New System.Drawing.Point(23, 257)
        Me.Label_Incremento.Name = "Label_Incremento"
        Me.Label_Incremento.Size = New System.Drawing.Size(60, 13)
        Me.Label_Incremento.TabIndex = 83
        Me.Label_Incremento.Text = "Incremento"
        '
        'TextBox_ConexionesNumero
        '
        Me.TextBox_ConexionesNumero.Location = New System.Drawing.Point(136, 388)
        Me.TextBox_ConexionesNumero.Name = "TextBox_ConexionesNumero"
        Me.TextBox_ConexionesNumero.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_ConexionesNumero.TabIndex = 86
        Me.TextBox_ConexionesNumero.Text = "120"
        '
        'TextBox_Incremento
        '
        Me.TextBox_Incremento.Enabled = False
        Me.TextBox_Incremento.Location = New System.Drawing.Point(89, 254)
        Me.TextBox_Incremento.Name = "TextBox_Incremento"
        Me.TextBox_Incremento.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Incremento.TabIndex = 84
        '
        'Button_GenerarRed
        '
        Me.Button_GenerarRed.Location = New System.Drawing.Point(24, 388)
        Me.Button_GenerarRed.Name = "Button_GenerarRed"
        Me.Button_GenerarRed.Size = New System.Drawing.Size(101, 23)
        Me.Button_GenerarRed.TabIndex = 64
        Me.Button_GenerarRed.Text = "GenerarRed"
        Me.Button_GenerarRed.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Chart1)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(714, 560)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Chart1
        '
        ChartArea3.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend3)
        Me.Chart1.Location = New System.Drawing.Point(4, 7)
        Me.Chart1.Name = "Chart1"
        Series5.ChartArea = "ChartArea1"
        Series5.Legend = "Legend1"
        Series5.Name = "Series_Prediccion"
        Series6.ChartArea = "ChartArea1"
        Series6.Legend = "Legend1"
        Series6.Name = "Series2"
        Me.Chart1.Series.Add(Series5)
        Me.Chart1.Series.Add(Series6)
        Me.Chart1.Size = New System.Drawing.Size(704, 300)
        Me.Chart1.TabIndex = 140
        Me.Chart1.Text = "Chart1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button_Circulo)
        Me.GroupBox2.Controls.Add(Me.Label_X1)
        Me.GroupBox2.Controls.Add(Me.Label_Resultado)
        Me.GroupBox2.Controls.Add(Me.Button_BorrarEntrenamiento)
        Me.GroupBox2.Controls.Add(Me.TextBox_Target)
        Me.GroupBox2.Controls.Add(Me.TextBox_X2)
        Me.GroupBox2.Controls.Add(Me.Button_Aentrenamiento)
        Me.GroupBox2.Controls.Add(Me.Label_X2)
        Me.GroupBox2.Controls.Add(Me.TextBox_X1)
        Me.GroupBox2.Controls.Add(Me.Button_APrueba)
        Me.GroupBox2.Controls.Add(Me.TextBox_Resultado)
        Me.GroupBox2.Controls.Add(Me.Label_Target)
        Me.GroupBox2.Location = New System.Drawing.Point(391, 350)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(320, 204)
        Me.GroupBox2.TabIndex = 139
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        '
        'Button_Circulo
        '
        Me.Button_Circulo.Location = New System.Drawing.Point(188, 19)
        Me.Button_Circulo.Name = "Button_Circulo"
        Me.Button_Circulo.Size = New System.Drawing.Size(110, 23)
        Me.Button_Circulo.TabIndex = 130
        Me.Button_Circulo.Text = "entrenamiento cIRCULO"
        Me.Button_Circulo.UseVisualStyleBackColor = True
        '
        'Label_X1
        '
        Me.Label_X1.AutoSize = True
        Me.Label_X1.Location = New System.Drawing.Point(29, 27)
        Me.Label_X1.Name = "Label_X1"
        Me.Label_X1.Size = New System.Drawing.Size(47, 13)
        Me.Label_X1.TabIndex = 119
        Me.Label_X1.Text = "Valor X1"
        '
        'Label_Resultado
        '
        Me.Label_Resultado.AutoSize = True
        Me.Label_Resultado.Location = New System.Drawing.Point(111, 130)
        Me.Label_Resultado.Name = "Label_Resultado"
        Me.Label_Resultado.Size = New System.Drawing.Size(71, 13)
        Me.Label_Resultado.TabIndex = 125
        Me.Label_Resultado.Text = "Resultado Y1"
        '
        'Button_BorrarEntrenamiento
        '
        Me.Button_BorrarEntrenamiento.Location = New System.Drawing.Point(188, 98)
        Me.Button_BorrarEntrenamiento.Name = "Button_BorrarEntrenamiento"
        Me.Button_BorrarEntrenamiento.Size = New System.Drawing.Size(110, 23)
        Me.Button_BorrarEntrenamiento.TabIndex = 129
        Me.Button_BorrarEntrenamiento.Text = "borrar entrenamiento"
        Me.Button_BorrarEntrenamiento.UseVisualStyleBackColor = True
        '
        'TextBox_Target
        '
        Me.TextBox_Target.Location = New System.Drawing.Point(82, 72)
        Me.TextBox_Target.Name = "TextBox_Target"
        Me.TextBox_Target.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Target.TabIndex = 124
        '
        'TextBox_X2
        '
        Me.TextBox_X2.Location = New System.Drawing.Point(82, 46)
        Me.TextBox_X2.Name = "TextBox_X2"
        Me.TextBox_X2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_X2.TabIndex = 122
        '
        'Button_Aentrenamiento
        '
        Me.Button_Aentrenamiento.Location = New System.Drawing.Point(188, 46)
        Me.Button_Aentrenamiento.Name = "Button_Aentrenamiento"
        Me.Button_Aentrenamiento.Size = New System.Drawing.Size(110, 23)
        Me.Button_Aentrenamiento.TabIndex = 127
        Me.Button_Aentrenamiento.Text = "a entrenamiento"
        Me.Button_Aentrenamiento.UseVisualStyleBackColor = True
        '
        'Label_X2
        '
        Me.Label_X2.AutoSize = True
        Me.Label_X2.Location = New System.Drawing.Point(29, 49)
        Me.Label_X2.Name = "Label_X2"
        Me.Label_X2.Size = New System.Drawing.Size(47, 13)
        Me.Label_X2.TabIndex = 121
        Me.Label_X2.Text = "Valor X2"
        '
        'TextBox_X1
        '
        Me.TextBox_X1.Location = New System.Drawing.Point(82, 20)
        Me.TextBox_X1.Name = "TextBox_X1"
        Me.TextBox_X1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_X1.TabIndex = 120
        '
        'Button_APrueba
        '
        Me.Button_APrueba.Location = New System.Drawing.Point(188, 72)
        Me.Button_APrueba.Name = "Button_APrueba"
        Me.Button_APrueba.Size = New System.Drawing.Size(110, 23)
        Me.Button_APrueba.TabIndex = 128
        Me.Button_APrueba.Text = "a prueba"
        Me.Button_APrueba.UseVisualStyleBackColor = True
        '
        'TextBox_Resultado
        '
        Me.TextBox_Resultado.Location = New System.Drawing.Point(188, 127)
        Me.TextBox_Resultado.Multiline = True
        Me.TextBox_Resultado.Name = "TextBox_Resultado"
        Me.TextBox_Resultado.Size = New System.Drawing.Size(103, 68)
        Me.TextBox_Resultado.TabIndex = 126
        '
        'Label_Target
        '
        Me.Label_Target.AutoSize = True
        Me.Label_Target.Location = New System.Drawing.Point(16, 75)
        Me.Label_Target.Name = "Label_Target"
        Me.Label_Target.Size = New System.Drawing.Size(60, 13)
        Me.Label_Target.TabIndex = 123
        Me.Label_Target.Text = "Target (S1)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button_CargarImagen)
        Me.GroupBox1.Controls.Add(Me.Button_GenerarEntrenaCirculo2)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Button_GenerarEntrenaCirculo)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.Button_GenerarDataSet)
        Me.GroupBox1.Controls.Add(Me.Button_DataSheEntrenamiento)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 382)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(363, 172)
        Me.GroupBox1.TabIndex = 138
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'Button_CargarImagen
        '
        Me.Button_CargarImagen.Location = New System.Drawing.Point(195, 32)
        Me.Button_CargarImagen.Name = "Button_CargarImagen"
        Me.Button_CargarImagen.Size = New System.Drawing.Size(119, 23)
        Me.Button_CargarImagen.TabIndex = 131
        Me.Button_CargarImagen.Text = "Cargar Imagen"
        Me.Button_CargarImagen.UseVisualStyleBackColor = True
        '
        'Button_GenerarEntrenaCirculo2
        '
        Me.Button_GenerarEntrenaCirculo2.Location = New System.Drawing.Point(137, 131)
        Me.Button_GenerarEntrenaCirculo2.Name = "Button_GenerarEntrenaCirculo2"
        Me.Button_GenerarEntrenaCirculo2.Size = New System.Drawing.Size(164, 23)
        Me.Button_GenerarEntrenaCirculo2.TabIndex = 137
        Me.Button_GenerarEntrenaCirculo2.Text = "Agrega entrena circulo "
        Me.Button_GenerarEntrenaCirculo2.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(55, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox1.TabIndex = 132
        Me.PictureBox1.TabStop = False
        '
        'Button_GenerarEntrenaCirculo
        '
        Me.Button_GenerarEntrenaCirculo.Location = New System.Drawing.Point(137, 102)
        Me.Button_GenerarEntrenaCirculo.Name = "Button_GenerarEntrenaCirculo"
        Me.Button_GenerarEntrenaCirculo.Size = New System.Drawing.Size(164, 23)
        Me.Button_GenerarEntrenaCirculo.TabIndex = 136
        Me.Button_GenerarEntrenaCirculo.Text = "Generar Entrena circulo"
        Me.Button_GenerarEntrenaCirculo.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(125, 32)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox2.TabIndex = 133
        Me.PictureBox2.TabStop = False
        '
        'Button_GenerarDataSet
        '
        Me.Button_GenerarDataSet.Location = New System.Drawing.Point(30, 102)
        Me.Button_GenerarDataSet.Name = "Button_GenerarDataSet"
        Me.Button_GenerarDataSet.Size = New System.Drawing.Size(101, 23)
        Me.Button_GenerarDataSet.TabIndex = 134
        Me.Button_GenerarDataSet.Text = "Generar DataSet"
        Me.Button_GenerarDataSet.UseVisualStyleBackColor = True
        '
        'Button_DataSheEntrenamiento
        '
        Me.Button_DataSheEntrenamiento.Location = New System.Drawing.Point(30, 131)
        Me.Button_DataSheEntrenamiento.Name = "Button_DataSheEntrenamiento"
        Me.Button_DataSheEntrenamiento.Size = New System.Drawing.Size(101, 23)
        Me.Button_DataSheEntrenamiento.TabIndex = 135
        Me.Button_DataSheEntrenamiento.Text = "DataSet a entrenamiento"
        Me.Button_DataSheEntrenamiento.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(740, 34)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(259, 136)
        Me.RichTextBox1.TabIndex = 158
        Me.RichTextBox1.Text = ""
        '
        'Label_TestArchivoIndice
        '
        Me.Label_TestArchivoIndice.AutoSize = True
        Me.Label_TestArchivoIndice.Location = New System.Drawing.Point(789, 565)
        Me.Label_TestArchivoIndice.Name = "Label_TestArchivoIndice"
        Me.Label_TestArchivoIndice.Size = New System.Drawing.Size(94, 13)
        Me.Label_TestArchivoIndice.TabIndex = 188
        Me.Label_TestArchivoIndice.Text = "Indice archivo test"
        '
        'TextBox_TestArchivoIndice
        '
        Me.TextBox_TestArchivoIndice.Location = New System.Drawing.Point(889, 562)
        Me.TextBox_TestArchivoIndice.Name = "TextBox_TestArchivoIndice"
        Me.TextBox_TestArchivoIndice.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_TestArchivoIndice.TabIndex = 187
        Me.TextBox_TestArchivoIndice.Text = "0"
        '
        'Button_EntrenamientoCsvVolumen
        '
        Me.Button_EntrenamientoCsvVolumen.Location = New System.Drawing.Point(783, 451)
        Me.Button_EntrenamientoCsvVolumen.Name = "Button_EntrenamientoCsvVolumen"
        Me.Button_EntrenamientoCsvVolumen.Size = New System.Drawing.Size(206, 23)
        Me.Button_EntrenamientoCsvVolumen.TabIndex = 196
        Me.Button_EntrenamientoCsvVolumen.Text = "Entrenamiento CSV Volumen"
        Me.Button_EntrenamientoCsvVolumen.UseVisualStyleBackColor = True
        '
        'Button_CargarDatosCSV
        '
        Me.Button_CargarDatosCSV.Location = New System.Drawing.Point(783, 311)
        Me.Button_CargarDatosCSV.Name = "Button_CargarDatosCSV"
        Me.Button_CargarDatosCSV.Size = New System.Drawing.Size(206, 36)
        Me.Button_CargarDatosCSV.TabIndex = 192
        Me.Button_CargarDatosCSV.Text = "Cargar CSV"
        Me.Button_CargarDatosCSV.UseVisualStyleBackColor = True
        '
        'Button_TestCSV
        '
        Me.Button_TestCSV.Location = New System.Drawing.Point(783, 533)
        Me.Button_TestCSV.Name = "Button_TestCSV"
        Me.Button_TestCSV.Size = New System.Drawing.Size(206, 23)
        Me.Button_TestCSV.TabIndex = 190
        Me.Button_TestCSV.Text = "Test CSV"
        Me.Button_TestCSV.UseVisualStyleBackColor = True
        '
        'Button_EntrenamientoCSV
        '
        Me.Button_EntrenamientoCSV.Location = New System.Drawing.Point(783, 353)
        Me.Button_EntrenamientoCSV.Name = "Button_EntrenamientoCSV"
        Me.Button_EntrenamientoCSV.Size = New System.Drawing.Size(206, 61)
        Me.Button_EntrenamientoCSV.TabIndex = 191
        Me.Button_EntrenamientoCSV.Text = "Entrenamiento CSV"
        Me.Button_EntrenamientoCSV.UseVisualStyleBackColor = True
        '
        'TextBox_LoadCSV_Asta
        '
        Me.TextBox_LoadCSV_Asta.Location = New System.Drawing.Point(889, 507)
        Me.TextBox_LoadCSV_Asta.Name = "TextBox_LoadCSV_Asta"
        Me.TextBox_LoadCSV_Asta.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_LoadCSV_Asta.TabIndex = 195
        Me.TextBox_LoadCSV_Asta.Text = "120"
        '
        'TextBox_LoadCSV_Desde
        '
        Me.TextBox_LoadCSV_Desde.Location = New System.Drawing.Point(783, 507)
        Me.TextBox_LoadCSV_Desde.Name = "TextBox_LoadCSV_Desde"
        Me.TextBox_LoadCSV_Desde.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_LoadCSV_Desde.TabIndex = 194
        Me.TextBox_LoadCSV_Desde.Text = "0"
        '
        'Label_LoadCSV
        '
        Me.Label_LoadCSV.AutoSize = True
        Me.Label_LoadCSV.Location = New System.Drawing.Point(848, 486)
        Me.Label_LoadCSV.Name = "Label_LoadCSV"
        Me.Label_LoadCSV.Size = New System.Drawing.Size(68, 13)
        Me.Label_LoadCSV.TabIndex = 193
        Me.Label_LoadCSV.Text = "Desde - Asta"
        '
        'TrackBar_TestCSV
        '
        Me.TrackBar_TestCSV.Location = New System.Drawing.Point(783, 259)
        Me.TrackBar_TestCSV.Name = "TrackBar_TestCSV"
        Me.TrackBar_TestCSV.Size = New System.Drawing.Size(206, 45)
        Me.TrackBar_TestCSV.TabIndex = 197
        '
        'ComboBox_Entrenamiento
        '
        Me.ComboBox_Entrenamiento.FormattingEnabled = True
        Me.ComboBox_Entrenamiento.Location = New System.Drawing.Point(783, 223)
        Me.ComboBox_Entrenamiento.Name = "ComboBox_Entrenamiento"
        Me.ComboBox_Entrenamiento.Size = New System.Drawing.Size(206, 21)
        Me.ComboBox_Entrenamiento.TabIndex = 198
        '
        'Label_ZoomEntradas
        '
        Me.Label_ZoomEntradas.AutoSize = True
        Me.Label_ZoomEntradas.Location = New System.Drawing.Point(815, 179)
        Me.Label_ZoomEntradas.Name = "Label_ZoomEntradas"
        Me.Label_ZoomEntradas.Size = New System.Drawing.Size(78, 13)
        Me.Label_ZoomEntradas.TabIndex = 200
        Me.Label_ZoomEntradas.Text = "Zoom entradas"
        '
        'TextBox_ZoomEntradas
        '
        Me.TextBox_ZoomEntradas.Location = New System.Drawing.Point(899, 176)
        Me.TextBox_ZoomEntradas.Name = "TextBox_ZoomEntradas"
        Me.TextBox_ZoomEntradas.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_ZoomEntradas.TabIndex = 199
        Me.TextBox_ZoomEntradas.Text = "1"
        '
        'Button_Entrenamiento2diasSaltosCSV
        '
        Me.Button_Entrenamiento2diasSaltosCSV.Location = New System.Drawing.Point(783, 420)
        Me.Button_Entrenamiento2diasSaltosCSV.Name = "Button_Entrenamiento2diasSaltosCSV"
        Me.Button_Entrenamiento2diasSaltosCSV.Size = New System.Drawing.Size(206, 23)
        Me.Button_Entrenamiento2diasSaltosCSV.TabIndex = 201
        Me.Button_Entrenamiento2diasSaltosCSV.Text = "Entrenamiento CSV 2"
        Me.Button_Entrenamiento2diasSaltosCSV.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 604)
        Me.Controls.Add(Me.Button_Entrenamiento2diasSaltosCSV)
        Me.Controls.Add(Me.Label_ZoomEntradas)
        Me.Controls.Add(Me.TextBox_ZoomEntradas)
        Me.Controls.Add(Me.ComboBox_Entrenamiento)
        Me.Controls.Add(Me.TrackBar_TestCSV)
        Me.Controls.Add(Me.Button_EntrenamientoCsvVolumen)
        Me.Controls.Add(Me.Button_CargarDatosCSV)
        Me.Controls.Add(Me.Button_TestCSV)
        Me.Controls.Add(Me.Button_EntrenamientoCSV)
        Me.Controls.Add(Me.TextBox_LoadCSV_Asta)
        Me.Controls.Add(Me.TextBox_LoadCSV_Desde)
        Me.Controls.Add(Me.Label_LoadCSV)
        Me.Controls.Add(Me.Label_TestArchivoIndice)
        Me.Controls.Add(Me.TextBox_TestArchivoIndice)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form1"
        Me.Text = "Perceptrón"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox_ImagenRed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar_TestCSV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label_LearningRate As Label
    Friend WithEvents Button_QuitarCapa As Button
    Public WithEvents ListBox_Neuronas As ListBox
    Friend WithEvents Button_AñadirCapa As Button
    Friend WithEvents PictureBox_ImagenRed As PictureBox
    Friend WithEvents ComboBox_CerebrosLista As ComboBox
    Friend WithEvents TextBox_Bias As TextBox
    Friend WithEvents Button_Cargar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox_GuardarNombre As TextBox
    Friend WithEvents Button_Guardar As Button
    Friend WithEvents TextBox_Capas As TextBox
    Friend WithEvents TextBox_Momento As TextBox
    Friend WithEvents Label_Momento As Label
    Friend WithEvents TextBox_AlfaEntrenamiento As TextBox
    Friend WithEvents Label_Independiente As Label
    Friend WithEvents TextBox_Salidas As TextBox
    Friend WithEvents TextBox_Independiente As TextBox
    Friend WithEvents TextBox_Neuronas As TextBox
    Friend WithEvents Label_Umbral As Label
    Friend WithEvents TextBox_EpocasEntrenamiento As TextBox
    Friend WithEvents TextBox_Umbral As TextBox
    Friend WithEvents Label_EpocasEntrenamiento As Label
    Friend WithEvents TextBox_FactorActivacion As TextBox
    Friend WithEvents Label_FactorActivacion As Label
    Friend WithEvents Label_Incremento As Label
    Friend WithEvents TextBox_ConexionesNumero As TextBox
    Friend WithEvents TextBox_Incremento As TextBox
    Friend WithEvents Button_GenerarRed As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button_Circulo As Button
    Friend WithEvents Label_X1 As Label
    Friend WithEvents Label_Resultado As Label
    Friend WithEvents Button_BorrarEntrenamiento As Button
    Friend WithEvents TextBox_Target As TextBox
    Friend WithEvents TextBox_X2 As TextBox
    Friend WithEvents Button_Aentrenamiento As Button
    Friend WithEvents Label_X2 As Label
    Friend WithEvents TextBox_X1 As TextBox
    Friend WithEvents Button_APrueba As Button
    Friend WithEvents TextBox_Resultado As TextBox
    Friend WithEvents Label_Target As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button_CargarImagen As Button
    Friend WithEvents Button_GenerarEntrenaCirculo2 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button_GenerarEntrenaCirculo As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Button_GenerarDataSet As Button
    Friend WithEvents Button_DataSheEntrenamiento As Button
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Label_TestArchivoIndice As Label
    Friend WithEvents TextBox_TestArchivoIndice As TextBox
    Friend WithEvents Button_Test As Button
    Friend WithEvents Button_DetenerNeurona As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button_EntrenamientoSencillo As Button
    Friend WithEvents Button_Entrenamiento As Button
    Friend WithEvents Button_EntrenamientoCsvVolumen As Button
    Friend WithEvents Button_CargarDatosCSV As Button
    Friend WithEvents Button_TestCSV As Button
    Friend WithEvents Button_EntrenamientoCSV As Button
    Friend WithEvents TextBox_LoadCSV_Asta As TextBox
    Friend WithEvents TextBox_LoadCSV_Desde As TextBox
    Friend WithEvents Label_LoadCSV As Label
    Friend WithEvents TrackBar_TestCSV As TrackBar
    Friend WithEvents ComboBox_Entrenamiento As ComboBox
    Friend WithEvents Label_ZoomEntradas As Label
    Friend WithEvents TextBox_ZoomEntradas As TextBox
    Friend WithEvents Button_Entrenamiento2diasSaltosCSV As Button
End Class
