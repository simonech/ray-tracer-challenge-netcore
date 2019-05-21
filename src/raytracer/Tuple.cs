namespace codeclimber.raytracer
{
    public class Tuple
    {
        public Tuple(float x, float y, float z, float w)
        {
            X=x;
            Y=y;
            Z=z;
            W=w;
        }
        
        public TupleType Type
        {
            get { 
                if(W==1.0f){
                    return TupleType.Point;
                }
                if(W==0.0f){
                    return TupleType.Vector;
                }
                return TupleType.Undefined;
            }
        }
        

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }

        public Tuple Add (Tuple other)
        {
            return new Tuple(
                X+other.X,
                Y+other.Y,
                Z+other.Z,
                W+other.W
            );
        }

        public Tuple Subtract (Tuple other)
        {
            return new Tuple(
                X-other.X,
                Y-other.Y,
                Z-other.Z,
                W-other.W
            );
        }

        public Tuple Negate()
        {
            return new Tuple(
                -X,
                -Y,
                -Z,
                -W
            );
        }

        public Tuple Multiply(float multiplier)
        {
            return new Tuple(
                X*multiplier,
                Y*multiplier,
                Z*multiplier,
                W*multiplier
            );
        }

        public Tuple Divide(float divisor)
        {
            return new Tuple(
                X/divisor,
                Y/divisor,
                Z/divisor,
                W/divisor
            );
        }

        public override bool Equals(object obj)
        {
            Tuple t = obj as Tuple;
            Tuple self = this as Tuple;
            if(t == null || self == null )
            {
                return false;
            }
            else
            {
                return (t.X.Equals(self.X)
                    && t.Y.Equals(self.Y)
                    && t.Z.Equals(self.Z)
                    && t.W.Equals(self.W));
            }
        }
    }

    public enum TupleType
    {
        Undefined,
        Vector,
        Point
    }
}