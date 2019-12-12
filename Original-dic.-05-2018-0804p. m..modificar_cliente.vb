Public Class modificar_cliente
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtCodCliente.Text <> "" Or txtNomCliente.Text <> "" Then
            txtCliente.Enabled = True
            txtDireccion.Enabled = True
            txtTel.Enabled = True
            txtCodCliente.Enabled = False
            txtNomCliente.Enabled = False
            btnBuscar.Enabled = False
            txtCliente.Select()
        Else
            txtCliente.Enabled = False
            txtDireccion.Enabled = False
            txtTel.Enabled = False
        End If
    End Sub

    Private Sub txtCodCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCodCliente.TextChanged, txtNomCliente.TextChanged
        If txtCodCliente.Text <> "" Or txtNomCliente.Text <> "" Then
            btnBuscar.Enabled = True
        Else
            btnBuscar.Enabled = False
        End If
    End Sub

    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCliente.TextChanged, txtTel.TextChanged, txtDireccion.TextChanged
        If txtCliente.Text <> "" And txtDireccion.Text <> "" And (txtTel.Text.Replace(" ", "").Count() = 12) Then
            btnModificar.Enabled = True
        Else
            btnModificar.Enabled = False
        End If
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        If (txtCliente.Text = "" And txtDireccion.Text = "" And Not (txtTel.Text.Replace(" ", "").Count() = 12)) Then
            cliente.Show()
            Me.Close()
        Else
            If (MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
                cliente.Show()
                Me.Close()

            End If
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        MessageBox.Show("Se ha modificado el cliente")
        txtCliente.Text = ""
        txtDireccion.Text = ""
        txtTel.Text = ""
        txtCliente.Enabled = False
        txtDireccion.Enabled = False
        txtTel.Enabled = False
        txtCodCliente.Text = ""
        txtNomCliente.Text = ""
        btnBuscar.Enabled = True
        txtCodCliente.Enabled = True
        txtNomCliente.Enabled = True
        btnModificar.Enabled = False
        txtCodCliente.Select()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub txtTel_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txtTel.MaskInputRejected
        If (txtTel.Text.Replace(" ", "").Count() >= 7) Then
            If txtDireccion.Text <> "" And txtCliente.Text <> "" Then
                btnModificar.Enabled = True
            Else
                btnModificar.Enabled = False
            End If
        Else
            btnModificar.Enabled = False
        End If
    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown, txtTel.KeyDown, txtDireccion.KeyDown
        If e.KeyCode = Keys.Enter Then
            If (txtTel.Text.Replace(" ", "").Count() >= 7) Then
                If txtDireccion.Text <> "" And txtCliente.Text <> "" Then
                    btnModificar_Click(sender, e)
                End If
            End If
        End If
    End Sub

    Private Sub txtCodCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtNomCliente.Text <> "" Or txtCodCliente.Text <> "" Then
                btnBuscar_Click(sender, e)
            End If
        End If
    End Sub
End Class