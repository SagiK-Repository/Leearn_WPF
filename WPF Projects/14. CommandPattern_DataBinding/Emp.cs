class Emp
{
    public string Ename { get; set; }
    public string Job { get; set; }

    public override string ToString()
    {
        return "[" + Ename + "," + Job + "]";
    }
}
