Public Class Trajetbus
    Private Sub Trajetbus_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnAjouter_Click(sender As Object, e As EventArgs) Handles BtnAjouter.Click
        ErrorProvider1.Clear()
        Dim r As New Reservations
        r.Options = New List(Of String)
        If LstLigne.SelectedIndex = -1 Then
            ErrorProvider1.SetError(LstLigne, "Veuillez selectionner un ligne!")
            Return
        End If
        If LstVilleDep.SelectedIndex = -1 Then
            ErrorProvider1.SetError(LstVilleDep, "Veuillez selectionner la ville de depart!")
            Return
        End If
        If LstVilleArrivee.SelectedIndex = -1 Then
            ErrorProvider1.SetError(LstVilleArrivee, "Veuillez selectionner la ville d'arrivée!")
            Return
        End If
        If LstVilleArrivee.Text = LstVilleDep.Text Then
            ErrorProvider1.SetError(LstVilleArrivee, " Veuillez selectionner une ville different!")
            Return
        End If
        If DTP_arv.Text = DTP_dep.Text Then
            ErrorProvider1.SetError(DTP_arv, " Veuillez selectionner deux temps differents!")
            Return
        End If
        If Num_places.Value = 0 Then
            ErrorProvider1.SetError(Num_places, " Veuillez selectionner au moins une place!")
            Return
        End If
        If Chk_Clima.Checked Then r.Options.Add("climatisation")
        If Chk_wifi.Checked Then r.Options.Add("Wifi")
        If Chk_etg.Checked Then r.Options.Add("bus à etage")
        If Radio_regu.Checked Then
            r.type = "regulier"
        ElseIf Radio_exp.Checked Then
            r.type = "express"
        ElseIf Radio_Noctu.Checked Then
            r.type = "nocturne"
        End If
        r.Options.Add(r.type)
        Dim optiontext As String = String.Join(",", r.Options)
        r.ligne = LstLigne.Text
        r.villeDepart = LstVilleDep.Text
        r.villeArrivee = LstVilleArrivee.Text
        r.h_debut = DTP_dep.Text
        r.h_fin = DTP_arv.Text
        r.places = Num_places.Value
        If AjouterReservation(r) Then
            DGV_Reservation.Rows.Clear()
            For Each i In ListeReservation
                DGV_Reservation.Rows.Add(i.ligne, i.villeDepart, i.villeArrivee, i.h_debut, i.h_fin, i.places, optiontext)
            Next

        Else
            MessageBox.Show("places insuffisantes")
        End If

    End Sub
End Class
