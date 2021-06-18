public class i
{
public int real;
public int vir;
public i(int x,int y)
{
this.real=x;
this.vir=y;
}
public i add(i c)
{
return new i(real+c.real,vir+c.vir);
}
public string tostr()
{
return real+"+"+vir+"i";
}
}