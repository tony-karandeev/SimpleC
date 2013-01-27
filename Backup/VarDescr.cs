namespace MathExpr
{
  public class VarDescr: IdentDescr
  {
    private string name = null;
    // используются интерпретатором
    private bool initialized = false;
    private double value = 0;


    public VarDescr(string name) {
      this.name = name;
    }


    public override int Type {
      get {
        return IdentDescr.VAR;
      }
    }


    public string Name {
      get {
        return name;
      }
    }


    // используется интерпретатором
    public double Value {
      get {
        return value;
      }
      set {
        this.value = value;
        initialized = true;
      }
    }
    // используется интерпретатором
    public bool Initialized {
      get {
        return initialized;
      }
    }


    public override string ToString() {
      return string.Format(":{0}", Name);
    }
  }
}
