<Window x:Class="Calculator.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Uno Calculator" Height="400" Width="300">
    <Grid>
        <TextBox x:Name="Display" FontSize="24" HorizontalAlignment="Stretch" VerticalAlignment="Top" Height="50" IsReadOnly="True" TextAlignment="Right"/>
        <UniformGrid Rows="5" Columns="4" Margin="0,60,0,0">
            <Button Content="7" Click="Button_Click"/>
            <Button Content="8" Click="Button_Click"/>
            <Button Content="9" Click="Button_Click"/>
            <Button Content="/" Click="Button_Click"/>
            <Button Content="4" Click="Button_Click"/>
            <Button Content="5" Click="Button_Click"/>
            <Button Content="6" Click="Button_Click"/>
            <Button Content="*" Click="Button_Click"/>
            <Button Content="1" Click="Button_Click"/>
            <Button Content="2" Click="Button_Click"/>
            <Button Content="3" Click="Button_Click"/>
            <Button Content="-" Click="Button_Click"/>
            <Button Content="0" Click="Button_Click"/>
            <Button Content="C" Click="Clear_Click"/>
            <Button Content="=" Click="Button_Click"/>
            <Button Content="+" Click="Button_Click"/>
        </UniformGrid>
    </Grid>
</Window>
