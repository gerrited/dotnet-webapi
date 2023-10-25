import http from 'k6/http';
import { sleep } from 'k6';

export default function () {
  http.get('https://k3s.g11s.cc/WeatherForecast');
}