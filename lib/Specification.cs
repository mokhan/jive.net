namespace jive
{
  public interface Specification<in T>
  {
    bool is_satisfied_by(T item);
  }
}
