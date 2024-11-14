
Dim values As New Dictionary(Of String, Double) From {
    {"city", If(city.IsNumeric, CDbl(city), 0)},
    {"flood", If(flood.IsNumeric, CDbl(flood), 0)},
    {"ins", If(ins.IsNumeric, CDbl(ins), 0)},
    {"mi", If(mi.IsNumeric, CDbl(mi), 0)},
    {"other1", If(other1.IsNumeric, CDbl(other1), 0)},
    {"other2", If(other2.IsNumeric, CDbl(other2), 0)},
    {"other3", If(other3.IsNumeric, CDbl(other3), 0)},
    {"taxes", If(taxes.IsNumeric, CDbl(taxes), 0)},
    {"usda", If(usda.IsNumeric, CDbl(usda), 0)}
}

Dim dbldiff As Double = CDbl(difference)

' Function to process each item
Private Sub ProcessItem(ByRef value As Double, ByRef remainingDiff As Double, ByRef target As String)
    If value <= remainingDiff Then
        target = remainingDiff.ToString()
        remainingDiff = 0
    Else
        remainingDiff -= value
    End If
End Sub

'Process each value in the dictionary
For Each key As String In values.Keys.ToList() 
    ' Process each value
    ProcessItem(values(key), dbldiff, key)
Next

' Update the original variables based on the final processed values
city = values("city").ToString()
flood = values("flood").ToString()
ins = values("ins").ToString()
mi = values("mi").ToString()
other1 = values("other1").ToString()
other2 = values("other2").ToString()
other3 = values("other3").ToString()
taxes = values("taxes").ToString()
usda = values("usda").ToString()

' Update the final difference
difference = dbldiff.ToString()