package greeter

object DemoFunctions extends Application {
  
  def func1(v: Int) = (3*v) + 2
  def func2(v: Int) = 4 - (5*v)
  
  println(func1(5) + func2(5))
  
}

