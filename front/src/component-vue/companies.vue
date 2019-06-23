<template>
	<div>
		<section v-for="item in info">
			<article>
				<router-link :to="{ path: '/company/' + item.Id}">{{item.Name}}</router-link>
			</article>
		</section>
	</div>
</template>

<script>
	import axios from 'axios';

	export default {
		name: 'companies',
		data() {
			return {
				info: null
			};
		},
		mounted() {
			axios
				.get('http://192.168.0.30:1488/api/companies/')
				.then(response => (this.info = response.data));
		}
	};
</script>
