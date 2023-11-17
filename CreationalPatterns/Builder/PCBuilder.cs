using System.Text;

namespace CreationalPatterns.Builder;

public class PCBuilder
{
    public PCBuilder()
    {
        pc = new Pc();

        pc.Motherboard = new Motherboard();
    }

    public PCBuilder SetSocket(string socket)
    {
        pc.Motherboard.Socket = socket;

        return this;
    }
    
    public PCBuilder SetCpu(int cores)
    {
        pc.Motherboard.Cpu = new Cpu();
        pc.Motherboard.Cpu.Cores = cores;
        // ...

        return this;
    }

    public PCBuilder SetGpu(int vram)
    {
        pc.Motherboard.Gpu = new Gpu();
        pc.Motherboard.Gpu.VRam = vram;
        // ...

        return this;
    }

    public PCBuilder SetSsd(int space)
    {
        if (space <= 0)
        {
            return this;
        }
        
        pc.Ssd = new Ssd();
        pc.Ssd.Space = space;
        
        // ...

        return this;
    }
    
    public PCBuilder SetRam(int amount)
    {
        if (amount <= 0)
        {
            return this;
        }
        
        pc.Motherboard.Ram = new Ram();
        pc.Motherboard.Ram.Amount = amount;

        // ...

        return this;
    }
    
    public PCBuilder SetPsu(int watt)
    {
        if (watt <= 0)
        {
            return this;
        }
        
        pc.Psu = new Psu();
        pc.Psu.Watt = watt;

        // ...

        return this;
    }
    
    public Pc Build()
    {
        // if (...) {}
        
        return pc;
    }

    private Pc pc;
}